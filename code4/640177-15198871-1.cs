    public void UpdateResultsOnScreen(string newContent)
    {
        txtResults.BeginInvoke(
            new Action<string>((value) =>
            {
                txtResults.Text += value;
            }),
            newContent);
    }
