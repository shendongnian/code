    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if (e.ColumnIndex == 0)
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.Format = "c";
                    }
                }
            }
