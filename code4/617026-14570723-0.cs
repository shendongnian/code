    // page 1
    var c = new clsRepLogs();
    c.setThoseAndThese();
    Session["mykey"] = c;
    
    // page 2
    var c = (clsRepLogs)Session["mykey"];
