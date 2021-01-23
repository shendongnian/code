        <asp:ObjectDataSource ID="ods" runat="server" 
            SelectMethod="GetQuestions" 
            TypeName="WebApplication1.Questions.QuestionsContext">
        </asp:ObjectDataSource>
        public IEnumerable<Question> GetQuestions()
        {
            // return your questions
        }
    public class Question
    {
        public Guid ID { get; set; }
        public string QuestionText { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public bool MultipleAnswers { get; set; }
        public bool IsCorrect { get; set; }
        public Question()
        {
            this.Answers = Enumerable.Empty<Answer>();
        }
    }
    public class Answer
    {
        public Guid ID { get; set; }
        public Question Question { get; set; }
        public bool IsCorrect { get; set; }
        public string AnswerText { get; set; }
        public bool WasSelected { get; set; }
    }
