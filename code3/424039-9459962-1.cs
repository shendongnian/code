    class Result
    {
        public string Data { get; set; }
    }
    class DiskResult : Result
    {
        public int FileSize { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
    class DiskRepository : IRepository<DiskResult>
    {
        public DiskResult[] Search(string data)
        {
            var results = new DiskResult[10];
            // .... add a bunch of stuff to the DiskResult array
            return results;
        }
    }
