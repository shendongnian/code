    private void button1_Click(object sender, EventArgs e)
    {
        for (var i = 0; i < 1000000; ++i)
        {
            richTextBox1.AppendText("I was trying to solve the problem in this Question but I ended up having another problem ");
            Application.DoEvents();
        }
    }
