    for (int r = 0; r < dt.Rows.Count; r++)
    {
        for (int c = 0; c < dt.Columns.Count; c++)
        {
            Response.Write(String.Join(", ", dt.Rows[r][c].ToString())); 
        }
        Response.Write("<br />");
    }
