    DataTable table = ...
    string[] strings = new string[table.Rows.Count];
    int idx = 0;
    foreach(DataRow row in table.Rows)
    {
        StringBuilder sb = new StringBuilder();
        object[] cells = row.ItemArray;
        for(int i = 0 ; i < cells.Length ; i++)
        {
            if (i != 0) sb.Append(',');
            sb.Append('"').Append(cells[i]).Append('"');
        }
        strings[idx++] = sb.ToString();
    }
