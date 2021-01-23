           private void metroGrid1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv_sender = sender as DataGridView;
            DataGridViewCell dgv_MouseOverCell=null;
            if (e.RowIndex > 0 && e.ColumnIndex > 0 && e.RowIndex <dgv_sender.RowCount && e.ColumnIndex<dgv_sender.ColumnCount)
            {
              dgv_MouseOverCell = dgv_sender.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
            if(dgv_MouseOverCell !=null)
            if (e.ColumnIndex == 4) {
                if (dgv_MouseOverCell.Value != null)
                {
                    if (File.Exists(dgv_MouseOverCell.Value.ToString()))
                    {
                        Image img = Image.FromFile(dgv_MouseOverCell.Value.ToString());
                        pictureBox1.ImageLocation = dgv_MouseOverCell.Value.ToString();
                        pictureBox1.Location = new System.Drawing.Point(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y);
                        pictureBox1.Visible = true;
                    }
                }
            }
        }
        private void metroGrid1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.Visible = false;
        }
