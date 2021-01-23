    public String GETUserList()
    {
        user  = new GET();
        user.urlAdress = url + "user";
        user.username = username;
        user.password = password;
    
        user.sendGETRequest();
    
        user.Completed += OutUser;
    
        if (Completed != null)
           Completed();
    
        user.mrse.WaitOne(); // <--- block until the event is raised
        return user.result;
    }
