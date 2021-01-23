    private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText != String.Empty)  
            {
                label1.Text = textBox1.SelectedText;
            }
            if (Clipboard.ContainsText())
            {
                label2.Text = Clipboard.GetText();
            }
        }
  
