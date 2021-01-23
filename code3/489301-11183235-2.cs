    [WebMethod]
    public GetUsersResponse[] LoadUsers()
    {
        if (HttpContext.Current.Session["Users"] != null) 
        {
            return (List<GetUsersResponse>)HttpContext.Current.Session["Users"];
        }
        return new List<GetUsersResponse>();
 
    }
    [WebMethod]
    public GetUsersResponse[] GetUsers(string query)
    {
        var users = new List<string>
        {
            "Brad Pitt",
            "Brad Pitt2",
            "Brad Pitt3",
            "Angelina Jolie",
            "Jeniffer Aniston",
            "Tom Cruise",
            "Katie Holmes",
            "Tom Hanks",
            "Sean Pen",
            "Jude Law",
            "Bruce Willis"
        };
        var returnUsers = users.Where(s => s.ToLower().Trim().StartsWith(query.ToLower().Trim()))
                         .Select(s => new GetUsersResponce { Name = s })
                         .ToArray();
        HttpContext.Current.Session["Users"] = returnUsers;
        HttpContext.Current.Session["Query"] = query;
        return returnUsers;
    }
    public class GetUsersResponse
    {
        public string Name { get; set; } 
    }
