    public class ClassX
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
    public class ClassY : ClassX
    {
        public int localeId { get; set; }
        public int clientId { get; set; }
    }
