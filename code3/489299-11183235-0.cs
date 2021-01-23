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
        return users.Where(s => s.ToLower().Trim().StartsWith(query.ToLower().Trim()))
                    .Select(s => new GetUsersResponce { Name = s })
                    .ToArray();
    }
    public class GetUsersResponse
    {
        public string Name { get; set; } 
    }
