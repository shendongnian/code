    public void Create(UserModel model) {
            _userNA = model.UserName;
            using (DatabaseCommaned cmd = new DatabaseCommaned()) {
            cmd.CommandText = "INSERT INTO tUser(UNA, FNAID, MNAID, LNAID, Email, MobCountryCode, Mobile, ST, LN, ExpDT) VALUES(@una, @fnaid, @mnaid, @lnaid, @email, @mobCode, @mobile, @st, @ln, @exp)";
            cmd.Parameters.AddWithValue("@una", userName);
            //....
    
    
            _userID = cmd.ExecuteInsertAndGetID();
            if (_userID > 0) {
                  copyPropertiesInternally();
                  Logs.LogEvent(LogEvent.UserCreated, userName);
                  ResetPassword();
                  return true;
            }
            else {
                  _userNA = string.Empty;
                  return false;
            }
        }
    }
