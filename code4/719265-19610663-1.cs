        webView.PropertyChanged += OnWebViewPropertyChanged;
        // ...
        private void OnWebViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "IsBrowserInitialized":
                    if (webView.IsBrowserInitialized)
                    {
                        webView.Load("http://some/url");
                    }
                    break;
            }
        }
