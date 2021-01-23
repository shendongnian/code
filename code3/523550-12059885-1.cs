    private void ProcessKeywords(Color clr)
    {
        foreach (Match m in keywordRegex.Matches(someLine)) {
            SelectionStart = m.Index;
            SelectionLength = m.Length;
            SelectionColor = clr;
        }
    }
