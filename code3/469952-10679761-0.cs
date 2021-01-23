    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+\s+(\d+)");
    System.Text.RegularExpressions.Match m = regex.Match("aaaa 3333");
    if(m.Success) {
        MessageBox.Show(m.Groups[1].Value);
    }
