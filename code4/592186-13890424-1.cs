    var list = new List<Tuple<int, int>>();
                list.Add(Tuple.Create(41, 73));
                list.Add(Tuple.Create(81, 103));
                list.Add(Tuple.Create(120, 150));
                // So, now we have three pair of values.   41-73, 81-103, 120-150
    
                //Now we can loop through the list and generate sequence using Enumerable.Range like this: 
                var values = new List<int>();
               list.ForEach(x =>values.AddRange(Enumerable.Range(x.Item1, x.Item2 - x.Item1 + 1)));
               
                //And print out items.
                values.ForEach(x => Console.WriteLine(x));
                //will print 41,42,43......73, 81,82,83....,103, 120, 121,.....150
