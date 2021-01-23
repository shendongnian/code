    //instead of:
    StaticService.Save(product);
    //you can do:
    public IService Service {get;set;}
    ...
    Service.Save(product);
    //and in your tests:
    yourObject.Service = new MockService(); //MockService inherits from your actual class or implements the same IService interface
