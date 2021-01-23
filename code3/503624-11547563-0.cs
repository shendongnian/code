    private void button1_Click(object sender, EventArgs e)
    {
        MyProcess myProcess = new MyProcess();
        string result = textBox1.Text;
        int number;
        if(int.TryParse(textBox1.Text, out number))
        {
            result = myProcess.AddTen(number).ToString();
        }
        textBox1.Text = result;
    }
