    public ActionResult Quotes() { 
        var quotes = service.GetQuotes(); //IEnumerable<Quote>
        return Json(quotes.Select(x=>new[] { EpochMillis(x.Date), (double)x.Closing }).ToArray());
    }
    
    private double EpochMillis(DateTime date)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        TimeSpan diff = date - origin;
        return Math.Floor(diff.TotalMilliseconds);
    }
