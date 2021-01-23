    var serialNumbers = from sn in str1 
		    group sn by sn.Substring(0, 10) into g
		    select new { 
                             Key = g.Key, 
                             Cnt = g.Count(), 
                             Min = g.Min(v => v.Substring(10)), 
                             Max = g.Max(v => v.Substring(10))
                         };
    foreach (var sn in serialNumbers)
    {
        Console.WriteLine("{0} {1}-{2} {3}(count)", sn.Key, sn.Min, sn.Max, sn.Cnt);
    }
