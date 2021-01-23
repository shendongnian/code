    public static List<List<List<T>>> AllPartitions<T>(this IEnumerable<T> set)
        {
            var retList = new List<List<List<T>>>();
            if (set == null || !set.Any())
            {
                retList.Add(new List<List<T>>());
                return retList;
            }
            else
            {
                for (int i = 0; i < Math.Pow(2, set.Count()) / 2; i++)
                {
                    var j = i;
                    var parts = new [] { new List<T>(), new List<T>() };
          
                    foreach (var item in set)
                    {
                        parts[j & 1].Add(item);
                        j >>= 1;
                    }
                    foreach (var b in AllPartitions(parts[1]))
                    {
                        var x = new List<List<T>>();
                        x.Add(parts[0]);
                        if (b.Any())
                            x.AddRange(b);
                        retList.Add(x);
                    }
                }
            }
            return retList;
        }
