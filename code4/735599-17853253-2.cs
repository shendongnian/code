    @using (Html.BeginForm("SubmitValue2","EnterValue",FormMethod.Post))
    {
    }
    
    //add this
    [HttpPost]
    public ActionResult submittedvalues2()
    {
        var model = SOMETHING;
        return View("submittedvalues", model);
    }
