    var missingNumbers = new List<int>();
    var minStop = list.OrderBy(x=>x.Stop).Min().Stop;
    var maxStart = list.OrderBy(x=>x.Start).Max().Start;
    Enumerable.Range(minStop, maxStart).ToList()
        .ForEach(x=>
            {
                if(!x.Between(x.Start, x.Stop, true))
                    missingNumbers.Add(x);
            }
        );
