    System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
    sc.Add("Test");
    sc.Add("Test2");
    
    string[] strArray = new string[sc.Count];
    sc.CopyTo(strArray,0);
