    public class User
    {
        public User(String name) {
            if (String.IsNullOrWhiteSpace(name)) {
                if (name == null) {
                    throw new System.ArgumentNullException("Cannot be null.", "name");
                }
                else {
                    throw new System.ArgumentException("Cannot be empty.", "name");
                }
            }
        }
    }
    public class SomeDataSource {
        public void AddUser(User user) {
            // Do your business validation here, and either throw or possibly return a value
            // If business rules pass, then add the user
            Users.Add(user);
        }
    }
