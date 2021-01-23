    StringBuilder innerXml = new StringBuilder();
    int methodId = 0;
    foreach(DataRow row in DT.Rows)
    {
        innerXml.AppendFormat("<Method ID='{0}' Cmd='New'>", methodId.ToString());
        methodId += 1;
        foreach(DataColumn column in DT.Columns)
        {
            innerXml.AppendFormat("<Field Name='{0}'>{1}</Field>", column.ColumnName, row[column.ColumnName]);
        }
        innerXml.AppendLine("</Method>");
    }
    batchElement.InnerXml = innerXml.ToString();
