    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        TextBox tBox = (TextBox)sender; 
        if (!((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
           || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
           || (e.KeyCode == Keys.Decimal && !(tBox.Text.Contains((char)'.')))
           || (e.KeyCode == Keys.OemPeriod && !(tBox.Text.Contains((char)'.')))
           || (e.KeyCode == Keys.Subtract && ((tBox.Text.Length == 0) || 
                    tBox.Text.EndsWith("e") || tBox.Text.EndsWith("E")))
           || (e.KeyCode == Keys.OemMinus && ((tBox.Text.Length == 0) || 
                    tBox.Text.EndsWith("e") || tBox.Text.EndsWith("E")))
           || e.KeyCode == Keys.Delete
           || e.KeyCode == Keys.Back
           || (e.KeyCode == Keys.E) && !(tBox.Text.Contains((char)'e')) && 
                    (tBox.Text.Contains((char)'.') && !tBox.Text.EndsWith("."))))
            {
                e.SuppressKeyPress = true;
            }
        }
