    List<string> replacedStrings = new List<string>();
    string replace = "";
        
         while (mysql.Reader.Read())
        {
           
            foreach(var field in mysql.Reader)
            {
              replace = field.replace(',','.');
              replacedStrings.add(replace); //<-- add each replaced string to the list
            }
         }
          
