    public ActionResult Foo()
    {
        if (string.Equals("post", Request.HttpMethod, StringComparison.OrdinalIgnoreCase)
        {
            // The POST verb was used to invoke the controller action
        }
        ...
    }
