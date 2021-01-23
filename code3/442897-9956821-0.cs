    dynamic settings = new ExpandoObject();
    settings.Filename = "asdf.txt";
    settings.Size = 10;
    ...
    
    function void Settings(dynamic settings)
    {
        if ( ((IDictionary<string, object>)settings).ContainsKey("Filename") )
            .... do something ....
    }
