       using (StreamReader reader = 
          File.OpenText(Server.MapPath(@daoWordPuzzle.GetfileURL())))
       {
           string line;
           while((line = reader.ReadLine()) != null)
           {
               Response.Write(line + " <br />");
           }
       }
