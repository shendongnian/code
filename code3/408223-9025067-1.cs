    public class User : BaseEntity<User>
    {
        public string FirstName { get; set; } 
     
        public string LastName { get; set; } 
     
        public string Username { get; set; } 
     
        // Custom Propreties 
        public string FullName 
        { 
            get 
            { 
                return FirstName + " " + LastName; 
            } 
        } 
     
        public string LastNameFirst 
        { 
            get 
            { 
                return LastName + ", " + FirstName; 
            } 
        } 
     
        public static string TableName 
        { 
            get 
            { 
                return "Users"; 
            } 
        } 
     
        public static User GetCurrentPerson(string username, KmManagerDbContext context) 
        { 
            try 
            { 
                // find the person who has the ad name = username 
                return context.Users.FirstOrDefault(p => p.Username.ToLower() == username.ToLower()); 
            } 
            catch (Exception ex) 
            { 
                throw new ApplicationException("There was an error retrieving the user from the database.", ex); 
            } 
        } 
    } 
