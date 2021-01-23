    public void LoginServiceConsumer(ILoginService service){
      //declare username and password
      IEnumerable<string> validationResult = service.Login(userName, password);
      if(validationResult.Any())
      // do the next operation
    }
