            DataTable table = new DataTable();
            foreach (IDictionary<string, object> row in DeviceTypeReport)
            {
                foreach (KeyValuePair<string, object> entry in row)
                {
                    if (!table.Columns.Contains(entry.Key.ToString()))
                    {
                        table.Columns.Add(entry.Key);
                    }
                }
                table.Rows.Add(row.Values.ToArray());
            }
