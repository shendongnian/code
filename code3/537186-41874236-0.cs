    private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Shift)
                {
                    if(e.KeyCode == Keys.Enter)
                    {
                        MessageBox.Show("shift enter");
                    }
                }
            }
