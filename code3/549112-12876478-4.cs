        public void DeleteExtraTableRows(string emailAddress, Excel.ListObject table)
        {
            try
            {
                var rowIndex = 0;
                var wasDeleted = false;
                while (rowIndex <= table.ListRows.Count)
                {
                    if (!wasDeleted) rowIndex++;
                    var row = table.ListRows[rowIndex];
                    var range = (Excel.Range)row.Range.Cells[1, 1];
                    var value = range.Value2;
                    if (value != null && !string.Equals(emailAddress, value.ToString()))
                    {
                        row.Delete();
                        wasDeleted = true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n\n" + e.StackTrace);
            }
        }
