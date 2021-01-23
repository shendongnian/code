     string value = listBoxAllModules.SelectedItem.Value; 
     string text = listBoxAllModules.SelectedItem.Text;  
     ListItem item = new ListItem (); 
     item.Text = text;                
     item.Value = value;
     listBoxStudentModules.Items.Add(item); 
     
