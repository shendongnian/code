        if (Request.Browser.Type.Contains("IE")) // replace with your check
    {
        ...
    } 
    else if (Request.Browser.Type.ToUpper().Contains("Chrome")) // replace with your check
    {
        if (Request.Browser.MajorVersion  < v1)
        { 
            DoSomething(); 
        }
        ...
    }
    else { }
