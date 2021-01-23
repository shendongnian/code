    string[] lines = File.ReadAllLines(path1);
    
    for(int i = 0; i < lines.Length; i++)
    {
      if(lines[i] = "25") lines[i] = "27");
    }
    
    File.WriteAllLines(path1, lines);
  
