        private void TxtName_KeyDown(object sender, KeyEventArgs e)
            {
                int i = TxtName.Text.Length;
                if(!(e.KeyData == Keys.Back && e.KeyData == Keys.Delete))
                    try
                    {
                        if (TxtName.Text.Length >= 20)
                        {
                            e.SuppressKeyPress = true;
                            e.Handled = true;
                        }
                    }
                    catch { } 
    }
