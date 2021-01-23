    public class Movie
    {
        public string MovieName {get;set;}
        public DateTime ProductionDate {get;set}
        public decimal Revenue  {get;set;}
        public List<MoviePerson> Stuff {get;set;}
    }
    
    public class MoviePerson
    {
       public enum PersonType{Actor,Director, ....}
       
       public string Name {get;set;}
       public string Surname {get;set;}
       public PersonType Duty {get;set}
       ...
    }
