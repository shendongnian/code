    string firstName;
    string lastName;
    if(fullname.Contains(","))
    {
        string[] splitNames = fullName.Split(",");
        lastName = splitNames[0];
        firstName = splitNames[1];
    }
    else if(splitNames.Contains(" "))
    {
        string[] splitNames = fullName.Split(" ");
        firstName = splitNames[0];
        lastName = splitNames[1];
    }
    else
    {
        //Some other logic.
    }
