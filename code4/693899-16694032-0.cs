    public class Quiz
    {
        public string Question { get; private set; }
        public string Answer { get; private set;}
        public Quiz(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }
    }
