    private void Login(object obj)
    {
        PasswordBox pwBox = obj as PasswordBox;
        SomeBlackBoxClass.ValidatePassword(UserName, pwBox.Password);
    }
