    for (int i = 1; i <= comboBox1.SelectedIndex + 1; i++)
    {
        TextBox textBox = (TextBox)FindName("tbEaveLength" + i);
        if (textBox.IsEnabled == false)
        {
            eaveLength{i} = 0;
        }
        else if (textBox.Text == "")
        {
            throw new Exception("EaveLength {i} must have a value");
        }
        else if (!double.TryParse(textBox.Text, out eaveLength{i}))
        {
           throw new Exception("EaveLength {i} must be numerical");
        }
    }
