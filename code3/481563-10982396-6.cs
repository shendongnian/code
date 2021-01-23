    // This annotation is required for all methods that can be accessed via AJAX calls
    [System.Web.Services.WebMethod]
    public static void GetUsers()
    {
       List<User> users = WhateverDataAccessYoureUsing.GetAllUsers();
       
       string listItems = string.Empty;
       // Loop through the list of users and create the option
       // that will be displayed inside of lbUsers
       foreach (User u in users)
       {
           listItems += CreateOption(u.Username);
       }
       // return the string value that will be appended on to lbUsers
       return listItems;
    }
    
    // This creates the html options that will be displayed 
    // inside of lbUser
    private string CreateOption(string text)
    {
       string option = "<option>" + text + "</option>"
    }
