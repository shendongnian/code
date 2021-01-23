    string Data = @"<?xml version=""1.0""?>
    <Notifications>
       <Alerts>
          <Alert>1</Alert>
          <Alert>2</Alert>
          <Alert>3</Alert>
       </Alerts>
    </Notifications>";
    
    
    XDocument.Parse(Data)
             .Descendants("Alert")
             .Where (node => int.Parse(node.Value) > 1 && int.Parse(node.Value) < 3)
             .ToList()
             .ForEach(al => Console.WriteLine ( al.Value ) );		// 2 is the result
