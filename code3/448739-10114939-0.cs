    var groupedUsers = users.GroupBy(x => x.FirstName)
    	 		.Select(x => new { Name = x.Key, Count = x.Count() });
    var dictionary = groupedUsers.ToDictionary(u=>u.Name, u=>u.Count);
    
    
    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    var output = serializer.Serialize(dictionary);
