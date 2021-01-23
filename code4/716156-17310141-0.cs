       using (StreamReader reader = 
          File.OpenText(Server.MapPath(@daoWordPuzzle.GetfileURL())))
       {
           //reader.ReadLine returns a string
           //so here you are iterating the first line of the file
           //this means line is a char
           foreach (var line in reader.ReadLine())
           {
               Response.Write(reader.ReadLine() + " <br />");
           }
       }
