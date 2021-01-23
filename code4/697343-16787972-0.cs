    Type type = myInstance.GetType();
    string fullName = type.FullName;
    string output;
    if (fullName.Contains(".Web"))
    {
        output = "this is webby";
    }
    else if (fullName.Contains(".Customer"))
    {
        output = "this is customer related class";
    }
    else
    {
        output = "unknown class";
    }
