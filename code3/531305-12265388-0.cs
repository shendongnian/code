    public static ActionResult SafeViewFromModel(
        Action<ResponseDataModel> setUpModel)
    {
        var model = new ResponseDataModel();
        try
        {
            setUpModel(model);
        }
        catch (Exception ex)
        {
            model.Error = true;
            model.Message = ex.ToString();
        }
        return View(model); 
    }
