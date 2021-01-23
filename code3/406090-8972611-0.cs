    SqlCommand sc = new SqlCommand();
        sc.CommandText = "usp_MyStoredProcedure";
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.Parameters.Add(AddParam(param1, "@param1"));
    DropDwonList DDList = new DropDownList()
    DDList = FindControl("DDCategories")
