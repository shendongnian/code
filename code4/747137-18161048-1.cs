    // Declare and initialize variables
    List<string> tickerList = new List<string>();
    
        // Get the string from the Settings
        string tickersProperty = Settings.Default["Tickers"].ToString();
    
        // Split the string and load it into a list of strings
        tickerList.AddRange(tickersProperty.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
        tickerList.AddRange(InputTickers.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
    
        Settings.Default["Tickers"] = String.Join(',', tickerList.Distinct().ToArray());
        Settings.Default["Tickers"].Save();
