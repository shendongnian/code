    private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
       {
           if (this.dataGridView2.Columns[e.ColumnIndex].Name == "Aidat")
           {
              string deger=(string)e.Value;
              deger = String.Format("{0:0.00}", deger);
           }
       }
