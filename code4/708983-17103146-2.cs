     ListBox.ObjectCollection ListItem1= ListBox1.Items; 
    
     if(!string.IsNullOrEmpty(SearchBox.Text)) 
     {
          foreach (string str in ListItem1)
          {                
             if (str.Contains(SearchBox.Text))
             {
                 msgbox;
             }
          }
     }
