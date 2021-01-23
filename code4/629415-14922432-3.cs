    var client = new WebClient();
    client.OpenReadCompleted += (sender, args) =>
    {
        using (var reader = new StreamReader(args.Result))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                // do something with the result
                // don't forget that this callback
                // is not invoked on the main UI thread so make
                // sure you marshal any calls to the UI thread if you 
                // intend to update your UI here.
            }
        }
    };
    client.OpenReadAsync(new Uri("http://example.com"));
