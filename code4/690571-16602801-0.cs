    public ActionResult Page()
    {
        //LINQ x expressions
        //LINQ y expressions
        if(Request.QueryString["type"] == "x")
        {
            return View(linqExpX.ToList());
        }
        else if(Request.QueryString["type"] == "y")
        {
            return View(linqExpY.ToList());
        }
        
        return someDefaultView; 
    }
