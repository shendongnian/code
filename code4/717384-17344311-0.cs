    public class Image
    {
        public int width { get; set; }
        public int height { get; set; }
        public string title { get; set; }
        public string location { get; set; }
    }
    
    public class Heading1
    {
        public string text { get; set; }
    }
    
    public class Body1
    {
        public string text { get; set; }
    }
    
    public class Heading2
    {
        public string text { get; set; }
    }
    
    public class Body2
    {
        public string text { get; set; }
    }
    
    public class DependencyLevel
    {
        public string question { get; set; }
        public string answer { get; set; }
    }
    
    public class SelectionOptions
    {
        public string availibleSelectionAmount { get; set; }
        public List<string> options { get; set; }
    }
    
    public class Control
    {
        public string type { get; set; }
        public SelectionOptions selectionOptions { get; set; }
    }
    
    public class AnswerOptions
    {
        public Control control { get; set; }
    }
    
    public class SelectedAnswer
    {
        public string selection { get; set; }
    }
    
    public class QuestionInformation
    {
        public string text { get; set; }
    }
    
    public class Question
    {
        public string questionNumber { get; set; }
        public DependencyLevel dependencyLevel { get; set; }
        public string questionText { get; set; }
        public AnswerOptions answerOptions { get; set; }
        public SelectedAnswer selectedAnswer { get; set; }
        public QuestionInformation questionInformation { get; set; }
    }
    
    public class DependencyLevel2
    {
        public string question { get; set; }
        public string answer { get; set; }
    }
    
    public class QuestionInformation2
    {
        public string text { get; set; }
    }
    
    public class SelectionOptions2
    {
        public string availibleSelectionAmount { get; set; }
        public List<string> options { get; set; }
    }
    
    public class Control2
    {
        public string type { get; set; }
        public SelectionOptions2 selectionOptions { get; set; }
    }
    
    public class AnswerOptions2
    {
        public Control2 control { get; set; }
    }
    
    public class SelectedAnswer2
    {
        public string selection { get; set; }
    }
    
    public class Queston
    {
        public string questionNumber { get; set; }
        public DependencyLevel2 dependencyLevel { get; set; }
        public string questionText { get; set; }
        public QuestionInformation2 questionInformation { get; set; }
        public AnswerOptions2 answerOptions { get; set; }
        public SelectedAnswer2 selectedAnswer { get; set; }
    }
    
    public class Category
    {
        public string name { get; set; }
        public List<Question> questions { get; set; }
        public string information { get; set; }
        public List<Queston> questons { get; set; }
    }
    
    public class FormBody
    {
        public Image image { get; set; }
        public Heading1 heading1 { get; set; }
        public Body1 body1 { get; set; }
        public Heading2 heading2 { get; set; }
        public Body2 body2 { get; set; }
        public List<Category> categories { get; set; }
    }
    
    public class RootObject
    {
        public string FormTitle { get; set; }
        public string FormId { get; set; }
        public string Type { get; set; }
        public FormBody FormBody { get; set; }
    }
