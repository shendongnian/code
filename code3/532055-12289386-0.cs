    var charCounts = array1.Concat(array2)
                        .GroupBy(c=>c)
                        .Select(g=>new Tuple<char, int>(g.Key, g.Count());
                        .OrderBy(t=>t.Item1);
    foreach(var result in charCounts)
       Console.WriteLine(String.Format("{0} = {1}", t.Item1, t.Item2));
    
