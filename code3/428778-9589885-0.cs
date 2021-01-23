    List<MyObject> inputList = new List<MyObject>();
    var resultSet = inputList
        .GroupBy(i => i.GetStartOfPeriodByMins(15))
        .Select( gr => 
        new { 
            StartOfPeriod = gr.Key, 
            Min = gr.Min(item => item.Value),
            Max = gr.Max(item => item.Value),
            Open = gr.OrderBy(item => item.Time).First().Value,
            Close = gr.OrderBy(item => item.Time).Last().Value
        });
