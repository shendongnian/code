    private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (excelDataGridView.Columns[e.ColumnIndex].Name.Equals("Links"))
            {
                 if(e.Value != null)
                    e.Value = Path.GetFileName(e.Value.ToString()); //change the display name for Hyperlink
            }
        }
