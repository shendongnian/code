    public class TargetList
    {
        public List<Target1> Targets { get; set; }
    }
    public class Target1
    {
        public Target2 Target;
    }
    public class Target2
    {
        public int Id { get; set; }
        public string EditUrl { get; set; }
    }
