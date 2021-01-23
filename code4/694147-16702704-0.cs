        DataGridViewCell clickedCell;
	
        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
    {
            try
        {
            DataGridView view = (DataGridView)sender;
                
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex >= 0)
            {
                Console.WriteLine("Clicked column " 
                           + e.ColumnIndex + ", row " 
                           + e.RowIndex + " of DataGridView " 
                           + view.Name + " at " 
                           + System.Windows.Forms.Cursor.Position);
               clickedCell = view.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
        }
    }
