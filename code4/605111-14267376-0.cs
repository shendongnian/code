    private void textBox1_TextChanged(object sender, EventArgs e)
            {
                try
                {
                    seed = Convert.ToInt32(textBox1.text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Input string is not a sequence of digits.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The number cannot fit in an Int32.");
                }
    
            }
