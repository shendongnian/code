    public void LoginServiceConsumer(ILoginService service){
      //declare username and password
      service.Login(userName, password);
      // do what after login, if throw exception then this operation will ensure to be cancelled automatically
    }
