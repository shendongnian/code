        public List<SymbolGroup> InvertGroup()
        {
            List<SymbolGroup> Results = new List<SymbolGroup>();
            foreach (iSymbol s in Symbols)
            {
                if (s is SymbolGroup)
                {
                    SymbolGroup sg = s as SymbolGroup;
                    sg.Parent = null;
                    Results.Add(s as SymbolGroup);
                }
                else if (s is Symbol)
                {
                    SymbolGroup sg = new SymbolGroup(null, SymRelation.AND);
                    sg.AddSymbol(s);
                    Results.Add(sg);
                }
            }
            bool AllChecked = false;
            while (!AllChecked)
            {
                AllChecked = true;
                for(int i=0;i<Results.Count;i++) 
                {
                    SymbolGroup result = Results[i];
                    if (result.Depth > 1)
                    {
                        AllChecked = false;
                        Results.RemoveAt(i--);
                    }
                    else
                        continue;
                    if (result.SymbolRelation == SymRelation.OR)
                    {
                        Results.AddRange(result.MultiplyOut());
                        continue;
                    }
                    for(int j=0;j<result.nSymbols;j++)
                    {
                        iSymbol s = result.Symbols[j];
                        if (s is SymbolGroup)
                        {
                            result.Symbols.RemoveAt(j--);   //removes the symbolgroup that is being replaced, so that the rest of the group can be added to the expansion.
                            AllChecked = false;
                            SymbolGroup subResult = s as SymbolGroup;
                            if(subResult.SymbolRelation == SymRelation.OR)
                            {
                                List<SymbolGroup> newResults;
                                newResults = subResult.MultiplyOut();
                                foreach(SymbolGroup newSg in newResults)
                                {
                                    newSg.Symbols.AddRange(result.Symbols);
                                }
                                Results.AddRange(newResults);
                            }
                            break;
                        }
                    }
                }
            }
            return Results;
        }
