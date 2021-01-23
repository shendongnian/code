    public bool checkUser(string user)
    {
    //User is allowed
    return true/false;
    }
    
    @if (checkUser(User.ToString())
    {
         <li>@Html.ActionLink("Index", "Admin")</li>
    }
