    private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                MessageBox.Show("You have Pressed '+'");
            }
            else if (e.KeyCode == Keys.Divide)
            {
                MessageBox.Show("You have Pressed '/'");
            }
            else if (e.KeyCode == Keys.Multiply)
            {
                MessageBox.Show("You have Pressed '*'");
            }
        }
    private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                MessageBox.Show("You have pressed '.'");
            }
            else if (e.KeyChar == '-')
            {
                MessageBox.Show("You have pressed '-'");
            }
        }
