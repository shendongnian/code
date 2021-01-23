    var values = new List<string>();
    // add each text box value to the list.
    
    HttpContext.Current.Session["Application"] = values;
    //To get them back
    var retrieved = HttpContext.Current.Session["Application"] as List<string>;
