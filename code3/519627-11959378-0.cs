    var lines = new List<string>();
    
    using (var fileStream = File.Open(xmlFilePath, FileMode.Open, FileAccess.Read))
       using(var reader = new TextReader(fileStream))
       {
          string line;
          while((line = reader.ReadLine()) != null)
             lines.Add(line);
       }   
        
    var i = lines.FindIndex(s=>s.StartsWith("<?xml"));
    var xmlLine = lines[i];
    lines.RemoveAt(i);
    lines.Insert(0,xmlLine);
    
    using (var fileStream = File.Open(xmlFilePath, FileMode.Truncate, FileAccess.Write)
       using(var writer = new TextWriter(fileStream))
       {
          foreach(var line in lines)
             writer.Write(line);
    
          writer.Flush();
       } 
     
