    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if ((e.CommandName == "MyDelete") && (e.CommandArgument != null))
        {
            
            //Add delete code here using e.CommandArgument to identify the correct record.
            //  For instance:
            MyDataObject obj = new MyDataObject();
            obj.RecordId = int.Parse(e.CommandArgument.ToString());
            MyDataObject.Delete(obj);
        }
    }
