    SecureString password;
    public string Password
    {
      internal get { return password.ConvertToInsecureString(); }
      set { password = value.ConvertToSecureString();
    }
