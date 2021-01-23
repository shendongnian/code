    private class UserAndUniversity {
        public User User {get; set;}
        public University University {get; set;}
    }
    public object MyMethod()
    {
        graph.Cypher
        .Start("user", "node(*)")
        .Match("user-[:STUDENT_AT]->university")
        .Where<User>(user =>
            user.Username != null &&
            user.Username.ToLower() == username.ToLower())
        .Return((user, university) => new UserAndUniversity
        {
            User = user.As<User>(),
            University = university.As<University>()
        })
        .Results;
    }
