    DataRow newRow =test.Tables[0].NewRow();
 
    newRow.ItemArray = Cache.getRowValues(child);
     test.Tables[0].Rows.InsertAt(newRow, c.Index+1);
    
     public string[] getRowValues(int index)
            {
                List<string> temp = new List<string>();
                foreach (KeyValuePair<int, CustomDataGridViewRow> dic in _cache)
                {
                    if (dic.Key == index)
                    {
                        foreach (DataGridViewCell cell in dic.Value.Cells)
                            temp.Add(cell.Value.ToString());
                    }
                }
                string[] result = temp.ToArray();
    
                return (result);
            }
