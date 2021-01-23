    // Side note - your simMethod argument doesn't seem to be used.
    public SimMatrix(string sparseMethod, string simMethod, Phrases phrases, DistrFeature features, int topK)
    {
        List<int> rows = new List<int>(phrases.uniquePhraseCount * topK);
        List<int> cols = new List<int>(phrases.uniquePhraseCount * topK);
        List<double> vals = new List<double>(phrases.uniquePhraseCount * topK);
        if (sparseMethod.Equals("invIdx"))
        {
            for (int i = 0; i < phrases.uniquePhraseCount; i++)
            { //loop through all phrases
                using (SparseDoubleArray row = phrases.feature_values.GetRowSparse(i))
                {
                    if (phrases.feature_values.RowLength(i) > 0)
                    { //i.e., at least one feature fired for phrase
                        // Declare your temporary collections when they're initialized
                        IEnumerable<int> nonzeros = row.Elements.Select(pmi => pmi.IndexList[1]);
                        var neighbors = generateNeighbors(nonzeros, features.inverted_idx);
                        IEnumerable<double> simVals = neighbors.Select(x => cosineSimilarity(row, phrases.feature_values.GetRowSparse(x)));
                        var sortedIdxSim = neighbors.Zip(simVals, (a, b) => new { idx = a, sim = b }).OrderByDescending(pair => pair.sim);
                        IEnumerable<int> sortedIdx = sortedIdxSim.Select(pair => pair.idx);
                        IEnumerable<double> sortedSim = sortedIdxSim.Select(pair => pair.sim);
                        int sortedInxSimCount = sortedIdxSim.Count();
                        int topN = (sortedInxSimCount < topK) ? sortedInxSimCount : topK;
                        rows.AddRange(Enumerable.Repeat(i, topN));
                        cols.AddRange(sortedIdx.Take(topN));
                        vals.AddRange(sortedSim.Take(topN));
                    }
                    else
                    { //just add self similarity
                        rows.Add(i);
                        cols.Add(i);
                        vals.Add(1);
                    }
                    Console.WriteLine("{0} phrases done", i + 1);
                }
            }
        }
        else { Console.WriteLine("Sorry, no other sparsification method implemented thus far"); }
        simMat = new SparseDoubleArray(phrases.uniquePhraseCount, phrases.uniquePhraseCount, rows, cols, vals);
    }
    static private List<int> generateNeighbors(IEnumerable<int> idx, Dictionary<int, List<int>> inverted_idx)
    {
        // Doing it this way will reduce memory usage since you won't be creating a bunch of temporary
        // collections, adding them to an existing collection, then creating a brand new collection
        // from it that is smaller... I think that may have been spiking your memory usage quite a bit.
        // This function may have been your main memory problem.
        return inverted_idx.Where(x => idx.Contains(x.Key)).SelectMany(x => x.Value).Distinct().ToList();
    }
