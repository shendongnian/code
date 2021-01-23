    // settings will automatically be used by JsonConvert.SerializeObject/DeserializeObject
    JsonConvert.DefaultSettings = () => new JsonSerializerSettings
	    {
	    Formatting = Formatting.Indented,
	    ContractResolver = new CamelCasePropertyNamesContractResolver()
	    };
		 
    Employee e = new Employee
	    {
	    FirstName = "Eric",
	    LastName = "Example",
	    BirthDate = new DateTime(1980, 4, 20, 0, 0, 0, DateTimeKind.Utc),
	    Department = "IT",
	    JobTitle = "Web Dude"
	    };
		 
    string json = JsonConvert.SerializeObject(e);
    // {
    //   "firstName": "Eric",
    //   "lastName": "Example",
    //   "birthDate": "1980-04-20T00:00:00Z",
    //   "department": "IT",
    //   "jobTitle": "Web Dude"
    // }
