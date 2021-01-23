    public ActionResult Foo { 
        Response.StatusCode = 403;
        Response.StatusDescription = "Some custom message";
        return View(); // or Content(), Json(), etc
    }
