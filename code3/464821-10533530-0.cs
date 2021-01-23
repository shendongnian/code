    private void button1_Click(object sender, EventArgs e)
    {
        if (ValueNotZero(numericUpDown1) && ValueNotZero(numericUpDown2))
            MessageBox.Show("You forgot to pay!");
        else if (!ValueNotZero(numericUpDown1) && !ValueNotZero(numericUpDown2))
            MessageBox.Show("One of the values must not be Zero!");
    }
    private bool ValueNotZero(NumericUpDown numericControl)
    {
        return (double)numericControl.Value > 0;
    }
