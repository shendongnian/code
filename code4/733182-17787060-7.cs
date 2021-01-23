    [HttpPost]   
    public virtual JsonResult Save(MyViewModel myViewModel)
    {
        if (ModelState.IsValid)
        {
             MyProcessManager.Save(myViewModel.prop1,myViewModel.prop2, myViewModel.prop3);
             return Json(myViewModel);
        }else
        {
             HttpContext.Response.StatusCode = 500;
             HttpContext.Response.Clear();
        }
        return Json(ModelState.SerializeErrors());
     }
