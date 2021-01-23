    StringBuilder innerXml = new StringBuilder("<Method ID='4' Cmd='New'>");
    foreach(DataRow row in DT.Rows)
    {
        foreach(DataColumn column in DT.Columns)
        {
            innerXml.AppendFormat("<Field Name='{0}'>{1}</Field>", column.ColumnName, row[column.ColumnName]);
        }
    }
    innerXml.AppendLine("</Method>");
    batchElement.InnerXml = innerXml.ToString();
