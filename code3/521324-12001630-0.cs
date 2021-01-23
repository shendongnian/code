    protected void btnExport_Click(object sender, EventArgs e)
    {
        var collection = GetTheDataSource(); // Get the source.
    	
        if (this.RadioButtonList1.SelectedIndex == 1)
        {
            //  take first 10 items from the collection		
    		collection = collection.Take(10); 
        }
        //set the grid source followed by binding it
    	this.GridView1.DataSource = collection;
    	this.GridView1.DataBind();
        //Export the grid record to excel
        GridViewExportUtil.Export("ContactsInformation.xls", this.GridView1);
    }
