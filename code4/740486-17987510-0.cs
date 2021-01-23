    public partial class Question
    {
        public int QuestionID { get; set; }
        public string QuestionBody { get; set; }
        public string CorrectAnswer { get; set; }
        public string AlternativeAnswer { get; set; }           
    
        public string SelectedAnswer { get; set; }
    }
