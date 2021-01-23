    DataTable dt = new DataTable();
    StringBuilder sb = new StringBuilder();
    sb.Append("<R>");
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        sb.Append("<C><ID>" + dt.Rows[0].ToString() + "</ID>");
        sb.Append("<N>" + dt.Rows[1].ToString() + "</N>");
        sb.Append("<I>" + dt.Rows[2].ToString() + "</I></C>");
    }
    sb.Append("</R>");
    ///pass XML string to DB side
    ///
    //sb.ToString(); //here u get all data from data table as xml format
