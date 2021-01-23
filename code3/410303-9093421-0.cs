    public class Case
    {
      ICollection<Question> Questions {get;set;}
    }
    
    public class Question
    {
      string Field1 {get;set;}
      Case Case {get;set;}
    }
    
    public class InheritedQuestion : Question
    {
      string Field2 {get;set;}
    }
