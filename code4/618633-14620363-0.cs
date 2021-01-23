    private void textBox1_KeyDown(object sender, KeyEventArgs e) // Keydown event in Textbox1
    {
      if (e.KeyCode == Keys.Enter) // Add text to TextBox2 on press Enter
      {
        textBox2.Text += textBox1.Text;
        textBox2.Text+= "\r\n"; // Add newline
        textBox1.Text = string.Empty; // Empty Textbox1
        textBox1.Focus(); // Set focus on Textbox1
      }
    }
