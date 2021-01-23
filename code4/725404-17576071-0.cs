    string[] parts = v.Split(',');
    List<string> grouped = new List<string>();
    
    for(int i = 0; i < parts.Length; i++)
        grouped.Add(parts[i].Trim() + "," + parts[++i].Trim());
