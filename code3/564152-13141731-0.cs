    char[] delemiterChars = { '-' };
    string text = txtProbe.Text;
    string[] words = text.Split(delemiterChars,StringSplitOptions.RemoveEmptyEntries);
    foreach (string s in words)
    {
            txtParse.Text += " " + s;
    }
