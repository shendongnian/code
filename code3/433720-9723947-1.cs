    for (int i = 0; i < lines.Count; i++)
    {
      ProcessIntersection(lines[i], lines[(i + 1) % lines.Count]);
    }
    
