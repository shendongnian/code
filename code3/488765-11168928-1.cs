    try this code
        
        String values = "";
        for (int i=0; i< cbl.Items.Count; i++)
        {
                if(cbl.Items[i].Selected)
                {
                        values += cbl.Items[i].Value + ",";
                }
        }
                               
        values = values.TrimEnd(',');
    
    
    
    	
    
    Or you can use this code (Linq)
    
    IEnumerable<int> allChecked = (from item in chkBoxList.Items.Cast<ListItem>() 
                                   where item.Selected 
                                   select int.Parse(item.Value));
