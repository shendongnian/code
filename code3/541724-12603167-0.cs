    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        QuoteParameters quote = e.Parameter as QuoteParameters;
        Debug.Assert(quote != null);
        var task = _viewModel.GenerateQuote(quote);
        string address = await task;
        webView.Source = new Uri(address);
    }
