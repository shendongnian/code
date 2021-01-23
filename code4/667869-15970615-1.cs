    private void button1_Click(object sender, EventArgs e)
            {
                if (button1.BackColor == Color.Red)
                {
                    button1.BackColor = Color.Green;
                    this.tabPage1.Text="1.Etasje" + ledigeRom++;
                 }
                else
                {
                    button1.BackColor = Color.Red;
                    this.tabPage1.Text = "1.Etasje" + ledigeRom--;
                   
                }  
            }
