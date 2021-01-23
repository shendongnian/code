    public void ConvertAndContinueWith(XDocument input, Action<XDocument> continueWith)
    {
        var ns = input.Root.Name.Namespace;
        var elements = input.Root.Descendants(ns + "a");
        int incompleteCount = input.Root.Descendants(ns + "a").Count;
        foreach (var element in elements)
        {
            Uri uri = new Uri((string)element.Attribute("href"));
            var wc = new WebClient();
            wc.OpenReadCompleted += ((sender, e) =>
            {
                element.Attribute("href").Value = e.Result.ToString();
                if (interlocked.Decrement(ref incompleteCount) == 0)
                   // This is the final callback, so we can continue executing.
                   continueWith(input);
            }
            );
            wc.OpenReadAsync(uri);
        }
    }
