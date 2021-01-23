    private readonly DateTime NODATE = new DateTime(1900, 1, 1);
    private DateTime loginTime;
    private void User_Changed(bool loggedIn) {
      if (loggedIn) {
        loginTime = DateTime.Now();
      } else {
        loginTime = NODATE;
      }
    }
