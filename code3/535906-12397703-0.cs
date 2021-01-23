    [Serializable]
    [XmlRoot("Task"), SoapType("Task")]
    public class TaskDto : IDto
    {
        public int ID { get; set; }
        public int TaskSequence { get; set; }
    }
