    DataSet valuesSet = getBlendInfo.GetProcessValues(reqID);
    foreach (DataRow dRow in valuesSet.Tables[0].Rows)
    {
        bool firstColumn = true;
        foreach (DataColumn dbColumn in valuesSet.Tables[0].Columns)
        {
            if (firstColumn)
                firstColumn = false;
            else
            {
                tblString.Append("<td>");
                tblString.Append(dRow[dbColumn].ToString());
                tblString.Append("</td>");
            }
        }
    }
