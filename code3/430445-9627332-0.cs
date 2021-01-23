    public ActionResult ActionMethod(FormCollection formCollection)
    {
        foreach (var key in formCollection.AllKeys)
        {
            var value = formCollection[key];
        }
    }
