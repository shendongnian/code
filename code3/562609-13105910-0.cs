    public class User
    {
        public enum eStatus
        {
             Client,
             Student
        }
    
        public static eStatus Status { get; set; }
    
        public static string Name { get; set; }  
    }
