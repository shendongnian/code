            while ((lines = sr.ReadLine()) != null)
            {
               var index = line.LastIndesOf(",,");
               lines = lines.Insert(index, "{"); 
               
               line.Add(lines+"}");                
            }   
    
