    public JObject GetJObject()
    {
    return new JObject("user", new JProperty("name", this.FirstName)); //so on
    }
    
    static User GetUserFromJObject(string json)
    {
    JObject obj = JObject.Parse(json);
    return new User() { FirstName = (string)obj["user"]["name"] }; //so on
    }
    
    public string UsersToElements (List<Users> users)
    {    
       JObject root = new JObject(from usr in users select new JAttribute("user", usr.GetJObject());
       return root.ToString();
    }
    
    public List<users> ElementsToUsers(string json)
    {
    List<Users> users = new List<Users>();
    JObject temp = JObject.Parse(json);
    foreach (JObject o in (JEnumerable<JObject>)temp.Children())
    {
    users.Add(Users.GetUserFromJObject(o.ToString());
    }
    return users;
    }
