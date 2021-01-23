    private void button1_Click_1(object sender, EventArgs e)
    {
         string[] names = textBox1.Text.Split(new string[] { " ", Environment.NewLine, "," }, StringSplitOptions.RemoveEmptyEntries);
         //you can add more parameters for splitting the string
         textBox2.Text = string.Join(",", names);
         //you can replace the comma with something more suitable for you
    }
