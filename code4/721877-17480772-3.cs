    DataTable dt = new DataTable();
    Dictionary<string,string> dict = new Dictionary<string,string>();
    dt.Columns.Add(new DataColumn("Name", typeof(string)));
    dt.Columns.Add(new DataColumn("Type", typeof(string)));
    foreach (DataDefinitionResponse dr in _dr)
    {
        if (dr.Type != "Group" && dr.Type != "File")
        {
            DataRow row = dt.NewRow();
            row["Name"] = dr["Name"].toString();
            row["Type"] = dr["Key"].toString;
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
