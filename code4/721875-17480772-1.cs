    DataTable dt = new DataTable();
    Dictionary<string,string> dict = new Dictionary<string,string>();
    dt.Columns.Add("Name");
    dt.Columns.Add("Type");
    foreach (DataDefinitionResponse dr in _dr)
    {
        if (dr.Type != "Group" && dr.Type != "File")
        {
            DataRow row = dt.NewRow();
            row["Name"] = dr["Name"];
            row["Type"] = dr["Key"];
            dt.Rows.Add(row);
        }
    }
    
    foreach(DataRow dr in dt.Rows)
    {
        dict.Add(dr.ItemArray[0].ToString(), dr.ItemArray[1].ToString());
    }
    ddlFieldName.DataSource = dict; // the dictionary should be here
    ddlFieldName.DataTextField = "Key";
    ddlFieldName.DataValueField = "Value";
    ddlFieldName.DataBind();
