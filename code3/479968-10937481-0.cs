    void Main()
    {
       List<string> alerts =
    
       XDocument.Parse(Data)
                .Descendants("Alerts")
                .Elements()
                .Select (nd => nd.Value)
                .ToList();
    
       alerts.ForEach(al => Console.WriteLine ( al ) );		// 3 2 1 on seperate lines
    
    }
    
    // Define other methods and classes here
    const string Data = @"<?xml version=""1.0""?>
    <Notifications>
       <Alerts>
          <Max>3</Max>
          <Med>2</Med>
          <Min>1</Min>
       </Alerts>
    </Notifications>";
