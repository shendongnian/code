            while ((lines = sr.ReadLine()) != null)
            {
               var index = line.LastIndesOf(",,") + 2;
               lines = lines.Insert(index, "{"); 
               
               line.Add(lines+"}");                
            }   
    
