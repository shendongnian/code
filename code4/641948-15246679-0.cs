       private void tbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Popup1.IsOpen = false;
                temp = tbx.Text;
                tbx.Text = null;
                e.Handled = true;
            }
        }
