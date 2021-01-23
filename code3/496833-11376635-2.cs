    var result = DB.SelectIntoItem("StoredProc_Name",
                                   connectionString,
                                   System.Data.CommandType.StoredProcedure,
                                   new { param1 = "val1" });
    if (!reader.Empty)
    {
       ltrlName.Text=result.Name;
       ltrlAddress.Text=result.Address;
    }
    etc.
