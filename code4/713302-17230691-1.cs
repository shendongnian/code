    class User
    {
        public string Name { get; set; }
        public int Age{ get; set; }
    }
    public static User GetUser()
    {
        var name = "x";
        var age = 1;
        return new User{Name = name, Age = age };
    }
    var user  = GetUser();
    string name = user.Name;
    int age = user.Age;
