    private void button1_Click(object sender, EventArgs e)
    {
         switch(textBox1.BackColor.Name)
         {
             case "Red":
                 textBox1.BackColor = Color.Green;
                 break;
             case "Green":
                 textBox1.BackColor = Color.Blue;
                 break;
             default:
                 textBox1.BackColor = Color.Red;
                 break;
         }
    }
