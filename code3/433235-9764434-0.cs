    public interface IOne
    {
       int ID {get;set;}
       string Code {get;set;}
    }
    public interface ITwo : IOne
    {
       DateTime CreatedDate {get;set;}
    }
