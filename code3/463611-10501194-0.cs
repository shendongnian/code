    if(UserLogic.PreInsertValidation(string username)){
       User newUser = new User(username);
    }
    else{
      // Handling - maybe show message on client "The username is already in use."
    }
