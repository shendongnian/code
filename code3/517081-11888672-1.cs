    void Application_Start(object sender, EventArgs e)
    {
        var userList = new List<string>();
        Application["UserList"] = userList;
    }
    void Session_Start(object sender, EventArgs e)
    {
        var userName = Membership.GetUser().UserName;
        List<string> userList;
        if(Application["UserList"]!=null)
        {
            userList = (List<string>)Application["UserList"];
        }
        else
            userList = new List<string>();
        userList.Add(userName);
        Application["UserList"] = userList;
    }
