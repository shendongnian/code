    public void AddValues() //add error handling
    {
        double a = double.Parse(textBox1.Text);
        double b = double.Parse(textBox2.Text);
        textBox3.Text = (a + b).ToString();
    }
