    TaskCompletionSource<string[]> tcs = new TaskCompletionSource<string[]>();
    WebClient[] webClients = new WebClient[urls.Length];
    object m_lock = new object();
    int count = 0;
    List<string> results = new List<string>();
    for (int i = 0; i < urls.Length; i++)
    {
        webClients[i] = new WebClient();
        // Specify the callback for the DownloadStringCompleted 
        // event that will be raised by this WebClient instance.
        webClients[i].DownloadStringCompleted += (obj, args) =>
        {
            // Argument validation and exception handling omitted for brevity. 
            // Split the string into an array of words, 
            // then count the number of elements that match 
            // the search term. 
            string[] words = args.Result.Split(' ');
            string NAME = name.ToUpper();
            int nameCount = (from word in words.AsParallel()
                             where word.ToUpper().Contains(NAME)
                             select word)
                            .Count();
            // Associate the results with the url, and add new string to the array that  
            // the underlying Task object will return in its Result property.
            results.Add(String.Format("{0} has {1} instances of {2}", args.UserState, nameCount, name));
            // If this is the last async operation to complete, 
            // then set the Result property on the underlying Task. 
            lock (m_lock)
            {
                count++;
                if (count == urls.Length)
                {
                    tcs.TrySetResult(results.ToArray());
                }
            }
        };
        // Call DownloadStringAsync for each URL.
        Uri address = null;
        address = new Uri(urls[i]);
        webClients[i].DownloadStringAsync(address, address);
    } // end for 
    await tcs.Task;
