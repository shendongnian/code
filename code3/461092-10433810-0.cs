    List<int> missingNumbers = new List<int>();
    Enumerable.Range(1, 10000).ToList()
        .ForEach(x=>
            {
                if(!x.Between(x.Start, x.Stop, true))
                    missingNumbers.Add(x);
            }
        );
