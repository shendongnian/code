    private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
    {
        SumAndDisplay();
    }
    private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
    {
        SumAndDisplay();
    }
    private void SumAndDisplay()
    {
        int a;
        int b;
        if (Int32.TryParse(textBox1.Text, out a) && Int32.TryParse(textBox2.Text, out b))
        {
            label1.Content = (a + b).ToString();
        }
    }
