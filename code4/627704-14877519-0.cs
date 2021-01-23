    List<User> myList = new List<User>();
    myList.Add(new User() { Name = "FUser", IsShow = true });
    myList.Add(new User() { Name = "FUser2", IsShow = true });
    myList.Add(new User() { Name = "FUser3", IsShow = true });
    myList.Add(new User() { Name = "BUser", IsShow = true });
    myList.Add(new User() { Name = "FUser4", IsShow = true });
    myList
        .Where(user => user.Name.StartsWith("F"))
        .Select(user => 
        { 
            user.IsShow = true; 
            return user; 
        });
