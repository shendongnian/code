    StringBuilder sb=new StringBuilder();
    foreach(string s in richTextBox1.Lines)
    {
        sb.AppendLine(s + " "+DateTime.Now.ToString("h:mm"));
    }
    richTextBox1.Text=sb.ToString();
