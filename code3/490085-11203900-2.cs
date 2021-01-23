    object newPareto1, newPareto2, part1, part2;
    foreach (DataGridViewRow item in coll)   
    {   
        //sorry for 1 -> 2 naming - it matched your ordering originally
        newPareto2 = item.Cells["NewPareto"].Value ?? DBNull.Value;
        part2 = item.Cells["Part"].Value ?? DBNull.Value;
        foreach (DataGridViewRow items in colls)   
        {   
          count++;  
          newPareto1 = items.Cells["NewPareto"].Value ?? DBNull.Value;
    
          if(newPareto1 != DBNull.Value && newPareto2 != DBNull.Value 
             && newPareto1.Equals(newPareto2))
          {
            part1 = items.Cells["Part"].Value ?? DBNull.Value;
      
            if(part1 != DBNull.Value && part2 != DBNull.Value 
               && !part1.Equals(part2))
            {
              listParts.Add(part1.ToString());
              dupi = true; //boolean toggle 
            }
          }
       }
    }
