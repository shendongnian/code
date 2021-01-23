    public abstract class QuestionPart {}
    
    public class ContentPart : QuestionPart {
     // holds the content
    }
    
    public class OptionsPart : QuestionPart {
     // holds the options and the answer
    }
    
    public class Question{
       public List<QuestionPart> questionParts {get; set;}
    }
    
    public class YourViewModel{
       public List<Question> questions {get; set;}
    }
