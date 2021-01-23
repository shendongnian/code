    public List<int> UserRoles{
        get{
            // optionally check that the value is indeed in session, otherwise this 
            // will throw
            return (List<int>)Session["UserRoles"];
        }
    }
