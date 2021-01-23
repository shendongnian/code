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
