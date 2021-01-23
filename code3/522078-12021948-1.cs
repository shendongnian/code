     Session["AllItems"]= CheckBoxList1.Items;    
        
        if ((Session["AllItems"]) != null)
            {
            ListItemCollection listitem =(ListItemCollection)Session["AllItems"];
            foreach(ListItem item in  listitem)
             {          
             CheckBoxList1.Items.Add(item);
             }
            }
