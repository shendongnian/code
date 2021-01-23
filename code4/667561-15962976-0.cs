    private void Form1_Load(object sender, EventArgs e)
    {
        foreach (TextBox textBox in this.Controls.OfType<TextBox>())
        {
            textBox.KeyDown += new KeyEventHandler(textBox_KeyDown);
        }
    }
    
    void textBox_KeyDown(object sender, KeyEventArgs e)
    {
       if (e.KeyCode == Keys.Enter)
       {
          e.Handled = true;
          SendKeys.Send("{TAB}");
       }
    }
