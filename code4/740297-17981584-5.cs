    dataGridView1.Columns[1].DefaultCellStyle.FormatProvider = new BoolFormatter();
    dataGridView1.Columns[1].DefaultCellStyle.Format = "YesNo";
    
    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
         if (e.CellStyle.FormatProvider is ICustomFormatter)
         {
             e.Value = (e.CellStyle.FormatProvider.GetFormat(typeof(ICustomFormatter)) as ICustomFormatter).Format(e.CellStyle.Format, e.Value, e.CellStyle.FormatProvider);
             e.FormattingApplied = true;
         }
     }
