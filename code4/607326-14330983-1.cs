    var service = new GeneratedProxyClient("basic");
    service.ClientCredentials.UserName.UserName = "test";
    service.ClientCredentials.UserName.Password = "password";
    var input = new InputParameters { Last_Name = "Cambre", First_Name = "Aren" };
    var returnData = service.BizarrePeopleSoftNameForMethod(input);
