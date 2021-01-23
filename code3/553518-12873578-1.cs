    void Main()
    {
        var lines = File.ReadAllLines("D:\\temp\\file.txt");
        for(int x = 0; x < lines.Length; x++)
        {
            // Of course this is an example of the condtion
            // you should implement your checks
            if(lines[x].Contains("CONDITION"))
            {
                lines[x] = lines[x].Replace("CONDITION", "CONDITION2");
            }
        
        }
        File.WriteAllLines("D:\\temp\\file.txt", lines);
    } 
  
