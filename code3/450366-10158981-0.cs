    var username = GetUserName();
    var password = GetPassword();
    var validationResult = new Validator().ValidateLogin(username, password);
    if(validationResult.ErrorMessage != null) {
        MessageBox.Show(validationResult.ErrorMessage);
    } else {
        // Do what you would have done.
    }
