        private void ClearSelectedTableRows()
        {
            if (Cache["TableRows"] != null)
            {
                tableRows = Cache["TableRows"] as List<TableRow>;
                Cache.Remove("TableRows");
                TableRow row = new TableRow();
                CheckBox rowBox = new CheckBox();
                List<TableRow> rowsToRemove = new List<TableRow>();
                for (int i = 0; i < tableRows.Count; i++)
                {
                    row = tblProducts.Rows[i+1]; // skip header row
                    rowBox = row.Cells[0].Controls[0] as CheckBox;
 
                    if (rowBox.Checked)
                        rowsToRemove.Add(tableRows[i]);                    
                }
                foreach (TableRow removeRow in rowsToRemove)
                {
                    if (tableRows.Contains(removeRow))
                        tableRows.Remove(removeRow);
                }
                TableRow headRow = tblProductsHead;
                tblProducts.Rows.Clear();
                tblProducts.Rows.Add(headRow);
                Cache.Insert("TableRows", tableRows, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
                PopulateTable();                
            }            
        }
