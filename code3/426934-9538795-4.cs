    // Define better name yourself
    // I believe IViewModel is pretty generic for your case
    public interface IViewModel
    {
       int memId { get; set; }
       int caseUserID { get; set; }
       bool isMember  { get; set; }
       bool isUser { get; set; }
    }
    
    class Activity : IViewModel
    { ... }
    
    class OpenTask : IViewModel
    { ... }
