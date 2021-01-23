    void Main()
    {
        List<User> myList = new List<User>();
        myList.Add(new User(){Name = "FUser", IsShow = true});
        myList.Add(new User(){Name = "FUser2", IsShow = true});
        myList.Add(new User(){Name = "FUser3", IsShow = true});
        myList.Add(new User(){Name = "BUser", IsShow = true});
        myList.Add(new User(){Name = "FUser4", IsShow = true});
    	
        // the magic happens here
    	var results = myList.Select(p=> new User { Name = p.Name, IsShow=p.Name.First()=='F'});
    }
        public class User
            {    
                public string Name { get; set;}
                public bool IsShow { get; set;}
            }
    
    // Define other methods and classes here
