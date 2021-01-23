    string[] webpages = { "http://www.google.com", "http://www.spiegel.de"};
	
    webpages
        .Select(w => FetchWebPage(w))
        .ForkJoin()
        .Subscribe(x => /*This runs when all webpages have been fetched*/  Console.WriteLine(x));
    //helper method to transform from the regular async way to the Rx way
    public static IObservable<string> FetchWebPage(string address)
    {
        var client = new WebClient();
        return Observable.Create<string>(observer =>
        {
            DownloadStringCompletedEventHandler handler = (sender, args) =>
            {
                if (args.Cancelled)
                    observer.OnCompleted();
                else if(args.Error != null)
                    observer.OnError(args.Error);
                else
                {
                    observer.OnNext(args.Result);
                    observer.OnCompleted();
                }
            };
            client.DownloadStringCompleted += handler;
            try
            {
                client.DownloadStringAsync(new Uri(address));
            }
            catch (Exception ex)
            {
                observer.OnError(ex);
            }
            return () => client.DownloadStringCompleted -= handler;
        });
    }
