    public ActionResult Foo()
    {
        HttpCookie mycookie = new HttpCookie("xyz");
        mycookie.Value = sessionId;
        mycookie.Expires = DateTime.Now.AddHours(9);
        Response.AppendCookie(mycookie);
        ...
    }
