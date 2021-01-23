    protected void button1_Click(object sender, EvenArgs e)
    {
       MyProcessor p = new MyProcessor();
       textBox1.Text = p.AddTen(textBox1.Text).ToString();
    }
