    public string userName
    {
        get
        {
           return userList.Single(r=>r.UserID == this.UserID).UserName; // Use single  
           //if you are sure there's going to be record against a user ID
           //Otherwise you may use First / FirstOrDefault
        }
    }
