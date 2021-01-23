    public class StackOverflowQuestion
    {
        private string _question;
    
        public string Question
        {
            get { return _question; }
            set
            { 
               if (String.IsNullOrEmpty(value))
               {
                   throw new ArgumentException("Question cannot be null or empty",
                                               "value");
               }
               _question = value;
            }
        }
    
        public StackOverflowQuestion(string question)
        {
            Question = question;
        }
    
        public override string ToString()
        {
            return Question;
        }
    }
