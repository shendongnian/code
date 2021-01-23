    public class MyModel
    {
        public List<SurveyHeader> SurveyHeaders { get; set; }
    }
    public class SurveyHeader
    {
        public string Name { get; set; }
        public List<SubHeader> SubHeaders { get; set; }
    }
    public class SubHeader
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
    public class Question
    {
        public int Value { get; set; }
        public string Question { get; set; }
    }
