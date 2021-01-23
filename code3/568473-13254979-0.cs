    private void button1_Click(object sender, EventArgs e)
    {
         switch(textBox1.BackColor)
         {
             case Color.Red:
                 textBox1.BackColor = Color.Green;
                 break;
             case Color.Green:
                 textBox1.BackColor = Color.Blue;
                 break;
             default:
                 textBox1.BackColor = Color.Red;
                 break;
         }
    }
