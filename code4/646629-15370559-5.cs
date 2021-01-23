    class User {
        public User(string first, string last) { ... }
        public User(uint age)  { ... }
        [Mandatory] public string FirstName { get; set; }
        [Mandatory] public string LastName { get; set; }
    }
    // client code:
    var actor = new User(82); // << invalid
    actor.FirstName = "Clint";
    actor.LastName = "Eastwood";
