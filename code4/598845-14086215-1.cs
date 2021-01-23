    string text = "abc /*defg*/ hij /*klm*/ xyz";
    richTextBox1.Text = text;
    Regex.Matches(text, @"\/\*(.*?)\*\/",RegexOptions.Singleline).Cast<Match>()
            .ToList()
            .ForEach(m =>
            {
                richTextBox1.Select(m.Index, m.Value.Length);
                richTextBox1.SelectionColor = Color.Blue;
                //or 
                //richTextBox1.Select(m.Groups[1].Index, m.Groups[1].Value.Length);
                //richTextBox1.SelectionColor = Color.Blue;
            });
