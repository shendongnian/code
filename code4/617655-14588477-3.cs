    public class Question
    {
        public string Text { get; set; }
        public string Answer { get; set; }
    
        public bool IsCorrect(string answer)
        {
            return String.Compare(answer, Answer, true) == 0;
        }
    }
