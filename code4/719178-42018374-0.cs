    public static string ConvertIntoJson(DataTable dt)
    {
        var jsonString = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            jsonString.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                    jsonString.Append("\"" + dt.Columns[j].ColumnName + "\":\"" 
                        + dt.Rows[i][j].ToString().Replace('"','\"') + (j < dt.Columns.Count - 1 ? "\"," : "\""));
                jsonString.Append(i < dt.Rows.Count - 1 ? "}," : "}");
            }
            return jsonString.Append("]").ToString();
        }
        else
        {
            return "[]";
        }
    }
    public static string ConvertIntoJson(DataSet ds)
    {
        var jsonString = new StringBuilder();
        jsonString.Append("{");
        for (int i = 0; i < ds.Tables.Count; i++)
        {
            jsonString.Append("\"" + ds.Tables[i].TableName + "\":");
            jsonString.Append(ConvertIntoJson(ds.Tables[i]));
            if (i < ds.Tables.Count - 1)
                jsonString.Append(",");
        }
        jsonString.Append("}");
        return jsonString.ToString();
    }
