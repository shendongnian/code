    class Search
    {
        public IEnumerable<Item> Start(params)
        {
            var client = new HttpClient(...);
            var resultsUri = client.Post(new SearchSpecification(params)).Response;
            Item item = client.Get<Item>(resultsUri);
            while(item != null)
            {
                yield return item;
                item = client.Get<Item>(resultsUri);
            }
        }
    }
