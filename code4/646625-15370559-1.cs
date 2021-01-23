    class User {
        public User(string first, string last) { ... }
        public User(uint age)  { ... }
        [Mandatory] public string FirstName { get; set; }
        [Mandatory] public string LastName { get; set; }
    }
    // client code:
    var user = new User(82); // << invalid
    user.FirstName = "Clint";
    user.LastName = "Eastwood";
