        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Value != null) // if condition is met, this cell will be painted
            {
                e.CellStyle.BackColor = Color.Black; // i used black color, feel free to replace it :)
            }
        }   
