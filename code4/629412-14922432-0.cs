    var client = new WebClient();
    client.OpenReadCompleted += (sender, args) =>
    {
        using (var reader = new StreamReader(args.Result))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                // do something with the result
            }
        }
    };
    client.OpenReadAsync(new Uri("http://example.com"));
