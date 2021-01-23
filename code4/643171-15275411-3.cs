    [TestMethod]
    public void ShouldFailIfUserNameIsTed(){
    
       var user = SetupUserScenario("Ted");
    
       var result = _myUserService.Validate(user);
    
       Assert.IsFalse(result);
    }
    
    private User SetupUserScenario(String username){
    
       var user = new User();
       user.Name = username;
    
       //Do a bunch of other necessary setup
    
       return user;
    }
