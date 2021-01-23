    public ActionResult Foo()
    {
    
        ResultType result;
        out string errorMessage;
        if (!TryXXX(input, out result, out errorMessage))
        {
            ModelState.AddModelError("", errorMessage);
            return View();
        }
    
        // here you could use the result
        ...
    
    }
