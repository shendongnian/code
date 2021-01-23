    public class Data
    {
        public Data()
        {
            Files = new Dictionary<string, FileData>();
        }
        public string Server { get; set; }
        public IDictionary<string, FileData> Files { get; set; } 
    }
    public class FileData
    {
        public string Source { get; set; }
        public string Format { get; set; }
    }
