    UserType userType;
    if (Enum.TryParse<UserType>(iUserType.ToString(), out userType))
    {
        //Yay! Parse succeeded. The userType variable has the value.
    }
    else
    {
        //Oh noes! The parse failed!
    }
