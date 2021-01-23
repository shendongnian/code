                foreach (DataRow row in dataTable.Rows)
                {
                    var dataGridRow = new DataGridViewRow();
                    dataGridRow.CreateCells(dataGrid);
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        dataGridRow.Cells[i].Value = row.ItemArray[i];
                    }
                    dataGrid.Rows.Add(dataGridRow);
                }
