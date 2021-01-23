    public ActionResult MillRequestCoil()
    {
        var model = CreateResponseDataModel(RunSpecificCode);
        return View(model);
    }
    public ActionResult MillDoSomethingElse ()
    {
        var model = CreateResponseDataModel(RunOtherCode);
        return View(model);
    }
    private static ResponseDataModel CreateResponseDataModel(Action<ResponseDataModel> action)
    {
        var model = new ResponseDataModel();
        try
        {
            action(model);
        }
        catch (Exception ex)
        {
            model.Error = true;
            model.Message = ex.ToString();
        }
        return model;
    }
    private void RunSpecificCode(ResponseDataModel model)
    {
        /* edit */
        //specific code
        const string coilId = "CC12345";
        //additional code
        model.Data = _dataRepository.DoSomethingToCoil(coilId);
        //replaced code
        //model.Data = new { Coil = coilId, M3 = "m3 message", M5 = "m5 message" };
        model.Message = string.Format("Coil {0} sent successfully", coilId);
    }
    private void RunOtherCode(ResponseDataModel obj)
    {
        // some other piece of code
    }
