    // Define better name yourself
    // I believe IViewModel is pretty generic for your case
    public interface IViewModel
    {
       string memId { get; set; }
       string caseUserID { get; set; }
       string isMember  { get; set; }
       string isUser { get; set; }
    }
    
    class Activity : IViewModel
    
    class OpenTask : IViewModel
