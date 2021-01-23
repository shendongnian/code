    [HttpPost]
    public ActionResult studentWeights(FormCollection formCollection)
    {
        foreach (string _formData in formCollection)
        {
            var x = formCollection[_formData];
        }
    }
