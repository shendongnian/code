    for (int i = 0; i < inventoryTimeBlocks.Count; i++)
    {
     if (line.Contains("a"))
         //next loop take "account1";
     else
     {
       if(i > 0)
       {
        i = i - 1;
        continue;
       }
     }
    }
