    private void Login(object obj)
    {
        PasswordBox pwBox = obj as PasswordBox;
        var encryptedPassword = SomeLibrary.EncryptValue(pwBox.Password, someKey);
        if (encryptedPassword == User.EncryptedPassword)
            // Success
    }
