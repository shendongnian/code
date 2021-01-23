    public void CallUser(){
      // declare the services and user here
      UserServiceFactory userServiceFactory = new UserServiceFactory(employeeService
        , managerService
        , executiveService);
      userServiceFactory.DoSomething(user);
    }
