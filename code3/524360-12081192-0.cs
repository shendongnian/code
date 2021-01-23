    public class ModelInfo
    {
        public int AssignedCount { get; set; }
        public int UnassignedCount { get; set; }
        public int TotalCount { get { return UnassignedCount + AssignedCount; } }
    }
