    var client = this.GetServiceClient(clientId);
    using (new OperationContextScope(client.InnerChannel))
    { 
        var request = new CreateUserRequest(user.Id, user.Person.FirstName, user.Person.LastName); 
        var response = client.CreateUser(request); 
    } 
