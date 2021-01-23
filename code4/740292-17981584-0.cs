    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
         if (e.ColumnIndex == yourcolumnIndex)
         {
             if (e.Value is bool)
             {
                 bool value = (bool)e.Value;
                 e.Value = (value) ? "Yes" : "No";
                 e.FormattingApplied = true;
             }
         }
     }
