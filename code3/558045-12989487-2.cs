    System.IO.StreamReader file = new System.IO.StreamReader(@"d:\test.txt");      
    while (file.EndOfStream != true)      
    {
      string s = file.ReadLine();
      Match m = Regex.Match(s, "\"([^\"]+)\"\\s+\"([^\"]+)\"", RegexOptions.IgnoreCase);
      if (m.Success) {
        richTextBox3.Text = Regex.Replace(richTextBox3.Text, 
          "\\b" + m.Groups[1].Value + "\\b", m.Groups[2].Value);
      }
    }
