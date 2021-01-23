        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                if (e.ColumnIndex == 0) //<-Column for String
                {
                    Console.WriteLine(dataGridView1[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString());
                    //Your Logic here
                }
                if (e.ColumnIndex == 1) //<-Column for Integer
                {
                    Console.WriteLine(dataGridView1[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString());
                    //Your Logic here
                }
            }
        }
