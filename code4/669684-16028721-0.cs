    string[] split = 
          convertText.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries);
    
     for (int index = 0; index < split.Count; index++)
     {
         split[index] = split[index].Trim();
     }
  
