    public class Talk {
      public string Message { get; set; } 
      public string[] TickerSymbols { get; set; }
    }
    var query = Query<Talk>.In(m => m.TickerSymbols, new string[]{"$MSFT"});
