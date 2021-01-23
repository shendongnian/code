    var cell = new DataGridViewImageCell
                {
                    Value = new Bitmap(@"C:\Path\to\image.jpg")
                };
    var row = new DataGridViewRow();
    row.Cells.Add(cell);
    dataGridView1.Columns.Add("columnName", "Column Header");
    dataGridView1.Rows.Add(row);
