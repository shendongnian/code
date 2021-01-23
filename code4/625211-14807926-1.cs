        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            var hitTest = dataGridView1.HitTest(e.X, e.Y);
            if (hitTest.Type == DataGridViewHitTestType.ColumnHeader)
            {
                List<string> data = new List<string>();
                //var getRows = dataGridView1.Rows.Cast<DataGridViewRow>().ToList();
                //foreach (var item in getRows)
                //    data.Add(item.Cells[1].EditedFormattedValue.ToString());
                if (dataGridView1.CurrentCell == null) return;
                var currentRowIndex = dataGridView1.CurrentCell.RowIndex;
                var getRows = dataGridView1.Rows[currentRowIndex].Cells.Cast<DataGridViewCell>().ToList();
                foreach (var item in getRows)
                    data.Add(item.EditedFormattedValue.ToString());
           
                string[] data1 = data.ToArray();
                dataGridView1.Columns[hitTest.ColumnIndex].ToolTipText = string.Join(", ", data1);
            }
        }
