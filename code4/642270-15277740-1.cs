    Parallel.For(0, Environment.ProcessorCount, i=>
    {
        while(ListOfSets.Count() > 0)
        {
            double SetID = 0;
            lock (ListOfSets)
            {
                SetID = ListOfSets[0].ID;
                ListOfSets.RemoveAt(0);
            }
         AnalyzeSet(SetID);
        }
    });
