    protected override void CreateChildControls()
    {
    	base.CreateChildControls();
    	Table table = new Table();
    	for (int i = 0; i < 3; i++)
    	{
    		TableRow tr = new TableRow();
    
    		TableCell tc1 = new TableCell();
    		tc1.Controls.Add(new LiteralControl(String.Format("Line {0}",i)));
    		tr.Cells.Add(tc1);
    
    		TableCell tc2 = new TableCell();
    		tc2.Controls.Add(new CheckBox() { Text = String.Format("CheckBox {0}", i), AutoPostBack = true});
    		tr.Cells.Add(tc2);
    
    		TableCell tc3 = new TableCell();
    		tc3.Controls.Add(new DropDownList() { Text = String.Format("DropDownList {0}", i) });
    		tr.Cells.Add(tc3);
    
    
    		table.Rows.Add(tr);
    	}
    	phMain.Controls.Add(table);
    }
