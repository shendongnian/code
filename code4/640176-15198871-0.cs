    public void UpdateResultsOnScreen(string newContent)
    {
        txtResults.Invoke(
            new Action<string>((value) =>
            {
                txtResults.Text += value;
            }),
            newContent);
    }
