    [HttpPost]
    public JsonResult Update([DataSourceRequest]DataSourceRequest request, MyObjectModel modelIn)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var myObject = _presentationService.Update(modelIn, User.Identity.Name);
                var myObjectList = new List<MyObjectModel> { myObject };
                return Json(myObjectList.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var myObjectList = new List<MyObjectModel> { modelIn };
                return Json(myObjectList.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
        }
        catch (Exception e)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(e);
            ModelState.AddModelError(string.Empty, e.Message);
            var myObjectList = new List<MyObjectModel> { modelIn };
            return Json(myObjectList.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
    }
