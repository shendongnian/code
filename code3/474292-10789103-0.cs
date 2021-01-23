    Task.Factory.StartNew(() =>
        {
            WebClient webClient = new WebClient();
            string source = webClient.DownloadString(
                "http://localhost/?search=" + search_string);
            return source;
        })
    .ContinueWith(antecedent =>
        {
            // Example use of result:
            this.resultTextBox.Result = antecedent.Result;
        },
        TaskScheduler.FromCurrentSynchronizationContext());
