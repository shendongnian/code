    public class QuestionDto
     {
        public QuestionDto()
        {
            this.Answers = new List<Answer>();
        } 
        public int QuestionId { get; set; }
        ...
        ...
        public string Title { get; set; }
        public List<Answer> Answers { get; set; }
    }
