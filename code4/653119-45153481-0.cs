    using System.Data;
           
    public static string DumpDataTable(DataTable table)
            {
                string data = string.Empty;
                StringBuilder sb = new StringBuilder();
    
                if (null != table && null != table.Rows)
                {
                    foreach (DataRow dataRow in table.Rows)
                    {
                        foreach (var item in dataRow.ItemArray)
                        {
                            sb.Append(item);
                            sb.Append(',');
                        }
                        sb.AppendLine();
                    }
    
                    data = sb.ToString();
                }
                return data;
            }
