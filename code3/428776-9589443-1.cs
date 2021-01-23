    List<TimeData> myList = new List<TimeData>();
    myList.Add(new TimeData(100, new DateTime(2012, 03, 01, 10, 0, 0)));
    myList.Add(new TimeData(50, new DateTime(2012, 03, 01, 10, 3, 0)));
    myList.Add(new TimeData(10, new DateTime(2012, 03, 01, 10, 35, 0)));
    myList.Add(new TimeData(230, new DateTime(2012, 03, 01, 10, 46, 0)));
    var grouped = myList.GroupBy(t => t.Time.Day.ToString()
           + "_" + t.Time.Month.ToString()
           + "_" + t.Time.Year.ToString()
           + "_" + t.Time.Hour.ToString() + "_"
           + (t.Time.Minute / 15).ToString())
       .Select(gr => new { TimeSlot = gr.Key, Max = gr.Max(item => item.Value),
             Min = gr.Min(item => item.Value),
             Open = gr.OrderBy(g => g.Time).First().Value,
             Close = gr.OrderBy(g => g.Time).Last().Value });
