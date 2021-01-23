            var winnersList = new List<Gameresults>();
            var losersList = new List<Gameresults>();
            //Populate the winnersList and losersList
            var winnersList1 = winnersList.Take(winnersList.Count/2).ToList();
            var winnersList2 = winnersList;
            var losersList1 = losersList.Take(losersList.Count/2).ToList();
            var losersList2 = losersList;
             var allLists = new List<List<Gameresults>> {winnersList1, winnersList2, losersList1, losersList2};
            var mergeRows = new List<MergeRow>();
            while (allLists.Any(l => l.Count > 0))
            {
                var resultsInOneRow = allLists.Select(l => l.DefaultIfEmpty(new Gameresults()).FirstOrDefault()).ToList();
                mergeRows.Add(GetMergeRow(resultsInOneRow));
            }
