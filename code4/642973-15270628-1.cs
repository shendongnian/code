    //Assuming your datatables are in ds (DataSet)
    ds.Tables[0].TableName = "Cats";
    ds.Tables[1].TableName = "Products";
    ds.Relations.Add("children", ds.Tables["Cats"].Columns["categoryno"],
                                 ds.Tables["Products"].Columns["categoryno"]);
    YourDataList.DataSource = ds;
    YourDataList.DataBind();
