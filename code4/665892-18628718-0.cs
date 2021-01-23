            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (row < 0 || col != 3)
                return;
            if (e.FormattedValue.ToString().Equals(String.Empty))
            {
            }
            else
            {
                double quantity = 0;
                try
                {
                    quantity = Convert.ToDouble(e.FormattedValue.ToString());
                    if (quantity == 0)
                    {
                        MessageBox.Show("The quantity can not be Zero", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("The quantity should be decimal value.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
