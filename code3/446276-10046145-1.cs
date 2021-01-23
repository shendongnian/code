    var sb = new StringBuilder();
    foreach (char t in richTextBox1.Text)
    {
        char encrypted = (char)(t + 3);
        sb.Append(encrypted);
    }
    richTextBox2.Text = sb.ToString();
