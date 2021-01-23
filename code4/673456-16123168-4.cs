    public class PocketDataRequest
    {
        public State? State { get; set; }
        public Favourite? Favourite { get; set; }
        public ContentType? ContentType { get; set; }
        public Sort? Sort { get; set; }
        public DetailType? DetailType { get; set; }
    
        public Dictionary<string, string> ToPostData()
        {
            return GetType().GetProperties()
                            .Where(p => p.GetValue(this, null) != null)
                            .ToDictionary(p => p.Name, 
                                          p => p.GetValue(this, null).ToString());
        }
    }
