    public static string ToCsv(DataTable table)
    {
        StringBuilder csv = new StringBuilder();
        
        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < row.ItemArray.Length; ++i)
            {
                if (i > 0)
                    csv.Append(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
        
                csv.Append(FormatValue(row.ItemArray[i]));
            }
        
            csv.AppendLine();
        }
        
        return csv.ToString();
    }
    
