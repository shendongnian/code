    public int DataTableToTable(DataTable dt,out string error)
    {
        error = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            finalSql = "INSERT INTO TABLENAME SELECT ";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                colValue += "'" + dt.Rows[i][j].ToString() + "',"; 
            }
            colValue = colValue.Remove(colValue.Length - 1, 1);
            finalSql += colValue + " FROM DUAL";
            InsertWithQuery(finalSql, out error);
            if (error != "")
               return error;
            inserts++;
            colValue = "";
        }
    }
