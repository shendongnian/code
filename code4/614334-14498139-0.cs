    private void BindTable(DataTable table)
            {
                    lvItemList.Clear();
    
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            ListViewItem lvItem = new ListViewItem();
                            lvItem.Text = row["ColumnName"].ToString();
                            lvItemList.Items.Add(lvItem);
                        }
                    }
                }
    
            }
