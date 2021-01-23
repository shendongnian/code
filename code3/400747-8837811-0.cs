    DataSet valuesSet = getBlendInfo.GetProcessValues(reqID);
    foreach (DataRow dRow in valuesSet.Tables[0].Rows)
    {
        foreach (DataColumn dbColumn in valuesSet.Tables[0].Columns)
        {
            tblString.Append("<td>");
            tblString.Append(dRow[dbColumn].ToString());
            tblString.Append("</td>");
        }
    }
