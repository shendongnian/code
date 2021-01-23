    Class Person
    {
       public String FirstName{get;set;}
       public String LastName {get;set;}
       public IEnumarable<Address> {get;set;}
    }
    
    Class Address
    {
       public String Address1 {get;set;}
       public String Address2 {get;set;}
    }
    
    Dynamic personData = new DynamicModel("connectionString","TableName","PrimaryKey");
    
    var resultPerson = personData.All(where: "where condition") 
    or 
    var resultPerson = personData.Query("Join query will be here")
    
    //Map resultPerson with PersonObject and return Person
    //Still this will be faster than EF as per benchmark shown on Dapper page
