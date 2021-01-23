    foreach (ListItem item in DropDownList.Items)
    {
     
     string s1 = "102";
     string s2 = item.Text;
    
     if(s2.Contains(s1))
     {
      item.Attributes.Add("style", "color:red");
     }
    } 
