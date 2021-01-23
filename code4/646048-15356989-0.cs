    public class Criteria
    {
        public string criteriaId { get; set; }
        public List<string> domains { get; set; }
        public List<string> domainsException { get; set; }
    }
    public class Configuration
    {
        public string id { get; set; }
        public List<Criteria> criterias { get; set; }
    }
    public class RootObject
    {
        public List<Configuration> configuration { get; set; }
        public string Status { get; set; }
    }
