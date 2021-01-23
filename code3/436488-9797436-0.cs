    int userIDInt;
    if (int.TryParse(userID, out userIDInt))
    {
        if (userIDInt == loggedID)
           // ...
    }
    else
        // handle the error
