    For i = Min to Max
    {
      if i < MaxFound
        continue;
    
      int step = 1;
      Output = i;
      while Found(i + Step)
      {
         Step++;
         MaxFound = i + Step;
      }
      if i < MaxFound 
        Output = (i + "-" + MaxFound);
    
      Output += ", ";
    }
