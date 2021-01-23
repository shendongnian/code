    public class Statistics
    {
        public Statistics()
        {
            Samples = new List<Sample>();
        }
        public List<Sample> Samples { get; set; }
    }
    public class Sample
    {
        public DateTime Date { get; set; }
        public float Duration { get; set; }
    }
