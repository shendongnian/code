    private void button1_Click(object sender, EventArgs e)
    {
         switch(textBox1.BackColor.ToArgb())
         {
             case Color.Red.ToArgb():
                 textBox1.BackColor = Color.Green;
                 break;
             case Color.Green.ToArgb():
                 textBox1.BackColor = Color.Blue;
                 break;
             default:
                 textBox1.BackColor = Color.Red;
                 break;
         }
    }
