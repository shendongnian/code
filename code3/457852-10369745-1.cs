    public class Question
    {
        public virtual int QuestionId { get; set; }
 
        public virtual string TheQuestion { get; set; }        
 
        public virtual IList<Answer> Answers { get; set; }
    }
    public class Answer
    {
        public virtual Question Question { get; set; }
 
        public virtual int AnswerId { get; set; }
 
        public virtual string TheAnswer { get; set; }                
    }
