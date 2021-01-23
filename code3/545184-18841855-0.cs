            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        { 
              // allowed only numeric value  ex.10
            //if (!char.IsControl(e.KeyChar)
            //    && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
                    
                   // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar)
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
