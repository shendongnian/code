    public class User
    {
        [key]    
        int UserID { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string E-mail { get; set; }
    
        [ForeignKey("UserProfile)]
        int CUserID { get; set; }
        virtual UserProfile UserProfile { get; set; ]
    }
