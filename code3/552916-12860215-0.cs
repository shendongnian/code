        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 id = (Int32)dataGridView1[0, e.RowIndex].Value;
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["NewDate"].Index)
            {
                if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["Delete"].Index) return;
                else
                {
    
                }
            }
            else
            {
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                panel2.Location=new Point(rect.X,rect.Y);
    
            }
    
        }
