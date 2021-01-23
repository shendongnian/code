    List<User> myUserList = new List<User>(); //Initialize a new List of Users
    //Add users to the list
    myUserList.Add(new User() { UserName = "bob", Password = "password" });
    myUserList.Add(new User() { UserName = "Joe", Password = "password" });
    myUserList.Add(new User() { UserName = "Miranda", Password = "password" });
    myUserList.Add(new User() { UserName = "Kevin", Password = "password" });
    //
    List<User> myGatheredList = new List<User>(); //Initialize a new List of Users of name myGatheredList (not required)
    foreach (User _user in myUserList.Where(x => x.UserName == "bob" && x.Password == "password")) //Only get values which match a UserName of value 'bob' and a password of value 'password' as _user for every User
    {
        Debug.WriteLine(_user.UserName); //Writes 'bob'.
        foreach (DigtalDiary _diary in _user.Diaries) //Get every DigitalDiary in _user.Diaries as _diary for every DigitalDiary
        {
            if (_diary.DisabledByAdmin /*&& _diary.Widgets.Count == x */ /* More conditions can be inserted here */) //Continue if _diary.DisabledByAdmin is true
            {
                foreach (Widget _widget in _diary.Widgets) //Get every Widget in _diary.Widgets as _widget for every Widget
                {
                    if (_widget.DisabledByAdmin) //Continue if _widget.DisabledByAdmin is true
                    {
                        if (!myGatheredList.Contains(_user)) //Continue if _user does not exist in myGatheredList
                        {
                            myGatheredList.Add(_user); //Add _user to myGatheredList (not required)
                           //Do something with _user
                        }
                    }
                }
            }
        }
    }
