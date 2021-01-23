    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if (e.ColumnIndex == 1) //Column ColB
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.Format = "c";
                    }
                }
            }
