    private T GetValueFromJsonResult<T>(JsonResult jsonResult, string propertyName)
    {
        var property =
            jsonResult.Data.GetType().GetProperties()
            .Where(p => string.Compare(p.Name, propertyName) == 0)
            .FirstOrDefault();
    
        if (null == property)
            throw new ArgumentException(propertyName + "not found", propertyName);
        return (T)property.GetValue(jsonResult.Data, null);
    }
    
    Boolean testValue = GetValueFromJsonResult<bool>(abc(), "Success");
    
    private JsonResult abc()
    {
        return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
    }
