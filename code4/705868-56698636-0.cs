       e.Control.KeyPress -= new KeyPressEventHandler(Column18qty_KeyPress);
                    if (dgvProduct.CurrentCell.ColumnIndex == 18) //dgvtxtQty
                    {
                        TextBox tb = e.Control as TextBox;
                        if (tb != null)
                        {
                            tb.KeyPress += new KeyPressEventHandler(Column18qty_KeyPress);
                        }
                    }
     private void Column18qty_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                // only allow one decimal point
                if (e.KeyChar == '.'
                    && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }
