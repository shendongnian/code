    private void button1_Click(object sender, System.EventArgs e)
    {
			
        if(parser.Intialize(textBox1.Text)==false)
	{
		MessageBox.Show("Check equation");
		return;
	}
	textBox4.Text=(parser.evaluate(double.Parse(textBox2.Text),double.Parse(textBox3.Text))).ToString();
    }
