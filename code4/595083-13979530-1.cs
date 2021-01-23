    List<object[]> grouped = olst
        .GroupBy(o => new { Prop1 = o[0].ToString(), Prop2 = o[1].ToString() })
        .Select(o => new object[] 
        {
            o.Key.Prop1,
            o.Key.Prop2,
            o.Sum(x => (int)x[2]),
            o.Sum(x => (double)x[3])
        })
        .ToList();
