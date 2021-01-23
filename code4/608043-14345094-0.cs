     using (StreamReader myStreamReader = new StreamReader(SQLQueryFileName)) 
     {
        string line;
        List<string> lines = new List<string();
    
        while ((line = myStreamReader.ReadLine()) != null)
            lines.Add(line.Trim());
    
        SQLQuery = string.Join("\n", lines);
        Console.WriteLine(SQLQuery);
     }
