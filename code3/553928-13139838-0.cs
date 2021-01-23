    for (int i = 0; i < dgv.Columns.Count; i++)
    {
        if (source.Columns[i].DataType == typeof(DateTime))
        {
            string val = source.Rows[0][i].ToString();
            if (val.EndsWith("12:00:00 AM") ||val.EndsWith("00:00:00"))
            {
                dgv.Columns[i].DefaultCellStyle.Format = "yyyy-MM-dd"; 
                //Your date Format
            }
            else
               dgv.Columns[i].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
               //Your date and Time Format
         }
    }
