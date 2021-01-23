    public class LoginResult
    {
       //determines if the login was successful
       public bool Success {get;set;}
    
       //the ID of the student, perhaps an int datatype would be better?
       public string StudentID {get;set;}
    
       //the error message (provided the login failed)
       public string ErrorMessage {get;set;}
    }
