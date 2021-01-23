    rtbMain.SelectAll();
    rtbMain.SelectionColor = Color.Black;
    rtbMain.SelectionBackColor = Color.White;
    Regex regex = new Regex(txtRegexPattern.Text, regexOptions);
    MatchCollection matches = regex.Matches(txtTest.Text);
    
    if(matches.Count > 0)
    {
       foreach(Match m in matches)
       {
          rtbMain.Select(m.Index, m.Length);
          rtbMain.SelectionColor = Color.Red;
          rtbMain.SelectionBackColor = Color.Black;
       }
    }
    else
    {
       Debug.Print("No matches found"); // See "Output" Window
    }
