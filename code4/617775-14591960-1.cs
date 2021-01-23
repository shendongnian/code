    public class WorkOutSession
    {
        public string Exercise { get; set; }
        public DateTime Date { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
        public int RestTime { get; set; }
        public int BodyWeight { get; set; }
    }
    public class WorkOutInformation
    {
        public List<WorkOutSession> Sessions { get; set; }
    }
