    dataModel.dataEntities de;
    dataModel.dataTable tbl;
    
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Create new entity object and table object
        de = new dataModel.dataEntities();
        de.Connection.Open();
        tbl = new dataModel.DataEntities();
        tbl.Field1 = ((TextBox)tbField1).Text.ToString(); ;
        tbl.Field2 = ((TextBox)tbField2).Text.ToString(); ;
        //Insert the row and save the change to the table
        de.AddToDataTable(tbl);
        de.SaveChanges();
        de.Connection.Close();
    }
