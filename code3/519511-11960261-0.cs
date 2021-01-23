    SqlDataAdapter myda = new SqlDataAdapter("Select * FROM " + Label3.Text, con);
    DataSet ds = new DataSet();
    myda.Fill(ds, "Table");
    LOC_LIST2.Items.Clear();
    LOC_LIST2.DataSource = ds.Tables[0];
    LOC_LIST2.DataTextField =     ds.Tables[0].Columns["Location_Instance"].ColumnName.ToString(); 
    LOC_LIST2.DataValueField=ds.Tables[0].Columns["Location_Type"].ColumnName.ToStri??ng(); 
    LOC_LIST2.DataBind(); 
    LOC_LIST2.Items.Insert(0, new ListItem("---Choose One Location---", "-1"));
