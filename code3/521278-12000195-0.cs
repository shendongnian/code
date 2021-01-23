     if(!Page.IsPostBack){  
            ArrayList listItems = new ArrayList();    
    
            listItems.Sort()
            CheckBoxList1.DataSource = listItems;  
            CheckBoxList1.DataBind();   
        } 
