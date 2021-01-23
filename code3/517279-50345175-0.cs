    int nextHigh = RTF.Text.IndexOf(txSearch, 0, StringComparison.OrdinalIgnoreCase);
    while (nextHigh >= 0)
    {
        RTF.Select(nextHigh, txSearch.Length);
        RTF.SelectionColor = Color.Red;                            // Or whatever
        RTF.SelectionFont = new Font("Arial", 12, FontStyle.Bold); // you like
        nextHigh = RTF.Text.IndexOf(txSearch, nextHigh + txSearch.Length, StringComparison.OrdinalIgnoreCase);
    }
