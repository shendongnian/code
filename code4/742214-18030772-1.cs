    public object[][] GetUsers()
    {
        List<object[]> users = new List<object[]>();
        //Get users and store them in variable called RealUsers or cycle through DataRows
        foreach(User user in RealUsers)
        {
            users.add(new object[]() {user.Name, user.Age});
        }
        return users.ToArray();
    }
