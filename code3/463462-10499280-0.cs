    IList<Data> testData = new List<Data>();
    testData.Add(new Data(){ Start = DateTime.Parse("6:00"), End = DateTime.Parse("6:30"), Value = 1});
    testData.Add(new Data(){ Start = DateTime.Parse("6:30"), End = DateTime.Parse("7:00"), Value = 1});
    testData.Add(new Data(){ Start = DateTime.Parse("7:00"), End = DateTime.Parse("7:30"), Value = 1});
    testData.Add(new Data(){ Start = DateTime.Parse("7:30"), End = DateTime.Parse("8:00"), Value = 1});
    
    var result = 
        from d in testData
        group d by d.Start.Hour into g
        select new Data() {Start = g.Min(m => m.Start), End = g.Max(m => m.End), Value = g.Sum(m => m.Value)};
