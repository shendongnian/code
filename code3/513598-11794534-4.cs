    Response.Redirect("yourpage.aspx?fname="+fname+"lname="+lname);
    // on second page get them as
    string fname = Request.QueryString["fname"];
    string lname = Request.QueryString["lname"];
    // or by using session pass these values as
    Session["fname"] = fname;
    Session["fname"] = lname;
   
    // and on the second page get them as
    string firstname = Session["fname"].ToString();
    string lasttname = Session["lname"].ToString();
    
