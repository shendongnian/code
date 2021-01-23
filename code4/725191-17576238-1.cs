    public ActionResult Myfunction(int? modelattr)
    {
        if (modelattr.HasValue()) //this will test if the nullable int has a value or is null
        {
            // do some code
        }
    }
