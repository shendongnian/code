    public class Score{
       public int TestId {get;set;}
       public int StudentId {get;set;}
       public int Score {get;set;}
    }
    
    public class Student{
       public int ID {get;set;}
       public string FirstName {get;set;}
       public string LastName {get;set;}
       public List<Score> Scores;
    }
