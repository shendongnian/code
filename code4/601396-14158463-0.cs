       string response = ASCIIEncoding.ASCII.GetString(bDataReceived);
    
       if (!String.IsNullOrWhiteSpace(response))
       {      
           saBytesReceived = response
                  .Split(new string[] { "\0" }, StringSplitOptions.None)
                  .Select(s => s.Replace("?", ""))
                  .Where(s => s.StartsWith("%"))
                  .ToArray();
       }
