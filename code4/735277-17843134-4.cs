    protected void SearchButtonClick(object sender, EventArgs e)
    {
        new Thread(() => MakeRequest(SearchForm.Text)).Start();
    }
    protected void MakeRequest(string text)
    {
        int resultCount = search.MakeRequests(text);
        // tell UI thread to update label
        Dispatcher.BeginInvoke(new Action(() =>
                {
                    resultsLabel.Text += text + ": " + resultCount + "     occurances";
                }));
    }
