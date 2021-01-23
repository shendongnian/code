    public class Account
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    
        public string Name { get; set; }
        public string Type { get; set;}
    }
    
    public class BusinessAccounts : Account { }
    
    public class PersonalAccounts : Account { }
