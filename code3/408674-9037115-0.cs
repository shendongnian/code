    StringBuilder sb = new StringBuilder();
    sb.AppendLine(richTextBox1.Rtf);
    sb.AppendLine();
    string myRTF = string.Empty;
    using (RichTextBox rtb = new RichTextBox()) {
      rtb.Rtf = richTextBox1.Rtf;
      rtb.SelectAll();
      sb.AppendLine(rtb.SelectedRtf);
    }
    string results = sb.ToString();
