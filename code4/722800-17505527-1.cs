    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
    
                {
                    if (!char.IsDigit(e.KeyChar) )
                    {
                        e.Handled = true;
    
                    }
                }
            }
