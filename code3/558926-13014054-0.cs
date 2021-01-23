	IList<DataModel> models = Logs
      .Where(x => x.Created >= dateMinimum && x.Created <= dateMaximum)
      .GroupBy(x => new { Year = x.Created.Year, Month = x.Created.Month, Day = x.Created.Day, Type = x.Type })
      .Select(x => new { Year = x.Key.Year, Month = x.Key.Month, Day = x.Key.Day, Count = x.Count(), Type = x.Key.Type })
      .AsEnumerable()
      .Select(x => new DataModel { Date = new DateTime(x.Year, x.Month, x.Day), LogsCount = x.Count, Type = x.Type })
      .ToList()
    public class DataModel
    {
    	public DateTime Date { get; set; }
    	public Int32 LogsCount { get; set; }
    	public string Type { get; set; }
    }
