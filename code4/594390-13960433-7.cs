    public class SectionModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<QuestionResultModel> Results { get; set; }
    }
    
    public class QuestionResultModel
    {
        public int Index { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
