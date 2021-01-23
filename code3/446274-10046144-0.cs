    StringBuilder enrypted = new StringBuilder();
    foreach (char t in richTextBox1.Text)
    {
        encrypted.Append((char)(t + 3));                
    }
    richTextBox2.Text = encrypted.ToString();
