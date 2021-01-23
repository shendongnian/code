     DropDownList ddl = new DropDownList();
    
            ddl.Visible = true;
    
            ddl.ID = "ddl1";
    
            ddl.Items.Add("Item1");
    
            TableCell cell = new TableCell();      
    
            gv.Rows[0].Cells.Add(cell);
    
            gv.Rows[0].Cells[0].Controls.Add(ddl);
