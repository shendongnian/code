       int line_number = 1;
       int startline = 15;
       int endline = 100;
       while ((line = reader.ReadLine()) != null)
       {
          if(line_number >= startline && line_number <= endline)  
          {
             //process the line  
          }
          line_number++;
       }
