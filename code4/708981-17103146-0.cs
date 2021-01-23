    var List1= Data.ToList(); //return original data 
    
     if(!string.IsNullOrEmpty(SearchBox.Text)) 
        {
          foreach (string str in List1)
          {                
             if (str.Contains(SearchBox.Text))
             {
                 msgbox;
             }
          }
        }
