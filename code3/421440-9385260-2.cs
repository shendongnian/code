    public class QuestionClass
    {
      public String Question { get; set; }
      public String Answer { get; set; }
    }
    public class QuizzClass
    {
      public Int32 ID { get; set; }
      [UIHint("Question")]
      public IList<QuestionClass> Questions { get; set; }
    }
