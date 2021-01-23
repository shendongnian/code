        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Point cursorPosition = dataGridView1.PointToClient(Cursor.Position);
                DataGridView.HitTestInfo info = dataGridView1.HitTest(cursorPosition.X, cursorPosition.Y);
                tableFactory = new data.TableFactory(TablesDropDown.SelectedValue.ToString());
                tableFactory.LoadTable(dbPath);
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (DataColumn col in tableFactory.Table.Columns)
                    {
                        if (col.ColumnName != "MIME" && col.ColumnName != "File")
                        {
                            tableFactory.NewColumn("MIME", ColumnTypes.String);
                            tableFactory.NewColumn("File", ColumnTypes.String);
                            tableFactory.SaveTable(dbPath);
                            ColumnsDataGrid();
                            dataGridView1.Rows[info.RowIndex].Cells["File"].Value = Convert.ToBase64String(GetFile(files));
                            FileInfo f = new FileInfo(files[0]);
                            dataGridView1.Rows[info.RowIndex].Cells["MIME"].Value = f.Extension;
                        }
                        else
                        {
                            dataGridView1.Rows[info.RowIndex].Cells["File"].Value = Convert.ToBase64String(GetFile(files));
                            FileInfo f = new FileInfo(files[0]);
                            dataGridView1.Rows[info.RowIndex].Cells["MIME"].Value = f.Extension;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("This was not a valid file to store in the database. Error Msg: " + ex.Message);
            }
        }
        private byte[] GetFile(string[] files)
        {
            byte[] bytes = null;
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (File.Exists(file))
                {
                    bytes = File.ReadAllBytes(file);
                }
            }
            return bytes;
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            button1.ForeColor = Color.Red;
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        if (col.Name == "File")
                        {
                            var buttonCell = new DataGridViewButtonCell();
                            buttonCell.Value = "Export File";
                            buttonCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridView1.Rows[i].Cells[col.Index] = buttonCell;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Grid Validation Error: " + ex.Message);
            }
        }
