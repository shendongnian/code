    [HttpPost]
    public ActionResult Process(FormCollection some_Dummy_Parameter_Thats_Not_Used_At_All_But_Which_We_Need_To_Avoid_The_Method_Overloading_Error_With_The_GET_Action_Which_Has_The_Same_Name)
    {
        var model = new MyViewModel();
        if (!TryUpdateModel(model))
        {
            // the model is invalid => redisplay view
            return View(model);
        }
    
        // at this stage the model is valid => you could do some processing here 
        // and redirect
        ...
    }
