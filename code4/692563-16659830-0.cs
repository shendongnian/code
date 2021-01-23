    public class UniversityStrategicGoalsModel
    {
        public Dictionary<string, string> Goals { get; set; }
        public IEnumerable<string> SelectedGoals { get; set; }
    
        public UniversityStrategicGoalsModel()
        {
            Goals = new Dictionary<string, string>()
            {
                {"NA", "Not Applicable"},
                {"1.1","1.1 blah blah blah"},
                {"1.2","1.2 and many more strategic goals"}
            };
        }
    }
