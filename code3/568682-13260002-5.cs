    private void radGridView1_CellValidating(object sender, Telerik.WinControls.UI.CellValidatingEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                if (e.Value != null && radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value != null)
                {
                    if (Double.Parse(e.Value.ToString()) <= Double.Parse(radGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()))
                    {
                        MessageBox.Show("error");
                        e.Cancel = true;                        
                    }
                }
            }
        }
