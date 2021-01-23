    enum BadgeClass {Bronze, Silver, Gold}
    
    //This class would be inherited from the database.
    public class Badge
    {
        public int Key {get;set;}
        public string Name {get;set;}
        public BadgeClass Class {get;set;}
        public string BadgeJob {get;set;}
        public string Description {get;set}
    }
