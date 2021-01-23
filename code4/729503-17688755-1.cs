    var lines = new List<string>();
    using(StreamReader sr = new StreamReader(response.GetResponseSteam())
    {
       while((var line = sr.ReadLine()) != null)
       {
           lines.Add(line);
       } 
    }
