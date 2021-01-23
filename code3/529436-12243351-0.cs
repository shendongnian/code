      if (str.IndexOf("|") > -1)
      {
           char vertLine = '\u2502'; 
           str = str.Replace("|", vertLine.ToString());
           doc.Add(new Phrase(str + "\n", s));
           continue;
        }
        if (str.StartsWith("---"))
        {  
             char vert = '\u2500'; 
             str = str.Replace("--", vert.ToString());
             doc.Add(new Phrase(str + str +"\n", s));
              continue;
          }
