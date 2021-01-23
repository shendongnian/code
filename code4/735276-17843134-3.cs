    protected void SearchButtonClick(object sender, EventArgs e)
    {
        Dispatcher.BeginInvoke(new Action(() => MakeRequest(SearchForm.Text)));
    }
    protected void MakeRequest(string text)
    {
        int resultCount = search.MakeRequests(text);
        resultsLabel.Text += text + ": " + resultCount + "     occurances";	
    }
