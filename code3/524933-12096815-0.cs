    protected void MakeDataTable()
    {
        table.Columns.Add("Part", typeof(string));
        table.Columns.Add("Quantity", typeof(Int32));
        table.Columns.Add("Ship-To", typeof(string));
        table.Columns.Add("Requested Date", typeof(string));
        table.Columns.Add("Shipping Method", typeof(string));
    
        //Persist the table in the Session object.
        Session["table"] = table;
    
        //Bind data to the GridView control.
        BindData();
    }
