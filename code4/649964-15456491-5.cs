    var totals = new int[NumberOfCandidates];
    foreach (VotingResult v in sortedResults) {
        Console.WriteL(v.Precinct + "\t\t");
        for (int cand = 0; cand < NumberOfCandidates; cand++) {
            Console.Write(v.Candidates[cand]  + "\t\t");
            total[cand] += v.Candidates[cand];
        }
        Console.WriteLine(v.PrecinctTotal);
    }
    Console.WriteLine("\nTOTAL RESULTS\t\t");
    for (int cand = 0; cand < NumberOfCandidates; cand++) {
         Console.Write(totals[cand]  + "\t\t");
    }
    Console.WriteLine();
