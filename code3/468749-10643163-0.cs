    public interface ISocialContact
    {
        string Name { get; }
    }
    public class FacebookContact : ISocialContact
    {
        public string Name { get; set; }
        public string FacebookPage { get; set; }
    }
    public class TwitterContact : ISocialContact
    {
        public string Name { get; set; }
        public string TwitterAccount { get; set; }
    }
