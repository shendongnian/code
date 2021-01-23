    public class User
    {
        private User(String name) {
            if (String.IsNullOrWhiteSpace(name)) {
                if (name == null) {
                    throw new System.ArgumentNullException("Cannot be null.", "name");
                }
                else {
                    throw new System.ArgumentException("Cannot be empty.", "name");
                }
            }
        }
        public static User CreateUser(String name) {
            User user = new User(name); // Lightweight instantiation, basic validation
            var matches = allUsers.Where(q => q.Name == name).ToList();
           
            if(matches.Any())           
            {           
                throw new System.ArgumentException("User with the specified name already exists.", "name");         
            }     
      
            Name = name;
        }
        public String Name {
            get;
            private set; // Optionally public if needed
        }
    }
