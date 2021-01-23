            while ((lines = sr.ReadLine()) != null)
            {
               var index = line.LastIndesOf(',');
               line = line.Insert(index, "{");
               line.Add(lines+"}");                
            }   
    
