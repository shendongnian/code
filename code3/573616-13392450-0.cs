    System.Collections.Specialized.StringCollection strs = new  System.Collections.Specialized.StringCollection();
    strs.Add("blah"); 
    strs.Add("blah"); 
    strs.Add("blah"); 
    
    string[] strArr = strs.Cast<string>().ToArray<string>();
