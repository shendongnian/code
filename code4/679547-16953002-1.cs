    private class YourModelClass
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
    var collection = new List<YourModelClass>();
    var collectionWrapper = new {
        myRoot = collection
    };
    var output = JsonConvert.SerializeObject(collectionWrapper);
