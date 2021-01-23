    public DataTable GetAllChechedBox()
            {
                var dt = new DataTable();
                        dt.Columns.Add("Name");
                        dt.Columns.Add("Value");
                for (int i = 0; i < chkList.Items.Count; i++)
                {
                    if (chkList.Items[i].Checked)
                    {
                      dt.Rows.Add();
                       dt.Rows[dt.Rows.Count-1]["Name"] = chkList.Items[i].Value;
                        dt.Rows[dt.Rows.Count-1]["Value"] = chkList.Items[i].Text;
                      
                    }
                }
            return dt;
        }
