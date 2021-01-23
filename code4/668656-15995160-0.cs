    using (StreamWriter writer = File.AppendText(saveFD.FileName))
    {
      writer.Write(richTextBox1.Text);
      writer.Write(richTextBox2.Text);
      writer.Write(richTextBox3.Text);
      writer.Write(richTextBox53.Text);
    }
