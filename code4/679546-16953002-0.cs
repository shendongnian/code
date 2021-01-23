    private class YourModelClass
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
    var collection = new List<YourModelClass>();
    dynamic collectionWrapper = new {
        myRoot = collection
    };
    var output = JsonConvert.SerializeObject(collectionWrapper);
