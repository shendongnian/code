    public class ViewModel1()
    {
        public PersonData myPerson {get; set;}
        // other properties
    }
    
    public class ViewModel2()
    {
        public PersonData myPerson {get; set;}
        // other properties
    }
    
    public class PersonData()
    {
        public string forename { get; set; }
        public string surname { get; set; }
        public string FormattedFullName 
        { 
            get 
            { 
                return string.Format("{0} {1}", forename, surname); 
            } 
        }
        // other properties
    }
