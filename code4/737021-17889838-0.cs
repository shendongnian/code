    if (something)
    {
        string foo = "Abc";
    }
    else if (somethingelse)
    {
        DateTime foo = DateTime.Now;
    }
    else
    {
        //Do nothing
    }
    Some.Method(foo); //What type is foo, string or DateTime? Does it even exist?
