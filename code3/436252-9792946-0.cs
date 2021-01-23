    DataTable dt = new DataTable();
    StringBuilder sb = new StringBuilder();
    foreach (DataRow dr in dt.Rows)
    {
        foreach (DataColumn dc in dt.Columns)
        {
            string cellValue = dr[dc] != null ? dr[dc].ToString() : "";
            sb.Append(" write your data here")
        }
    }
