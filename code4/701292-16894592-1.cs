     DataTable dtt = (DataTable)Session["ByBrand"];
     DataRow[] rows = dtt.Select("Price >= " + HiddenField1.Value + " and Price <= " + HiddenField2.Value + "");
    if(rows.Length > 0)
    {
        var filldt = rows.CopyToDataTable();
    }
