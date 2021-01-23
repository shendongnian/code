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
    		CheckBox chb = new CheckBox();
    		chb.ID = String.Format("CheckBox_{0}", i);
    		chb.Text = String.Format("CheckBox {0}", i);
    		chb.CheckedChanged += chb_CheckedChanged;
    		chb.AutoPostBack = true;
    		tc2.Controls.Add(chb);
    		tr.Cells.Add(tc2);
    		TableCell tc3 = new TableCell();
    		DropDownList ddl = new DropDownList();
    		ddl.ID = String.Format("DropDownList_{0}", i);
    		ddl.Items.Add("1111");
    		ddl.Items.Add("2222");
    		ddl.Items.Add("3333");
    		ddl.SelectedIndex = i;
    		ddl.Enabled = false;
    		tc3.Controls.Add(ddl);
    		tr.Cells.Add(tc3);
    
    
    		table.Rows.Add(tr);
    	}
    	phMain.Controls.Add(table);
    }
    
    void chb_CheckedChanged(object sender, EventArgs e)
    {
    	CheckBox chb = sender as CheckBox;
    	string ddlid = chb.ID.Replace("CheckBox", "DropDownList");
    	DropDownList ddl = this.Page.FindControl(ddlid) as DropDownList;
    	if (ddl != null)
    	{
    		ddl.Enabled = chb.Checked;
    	}
    }
