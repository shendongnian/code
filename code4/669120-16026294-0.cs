        private void kryptonDataGridView1_CellEnter(object sender, 
                                                    DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                kryptonDataGridView1.BeginEdit(true);
            }
        }
