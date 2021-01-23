    public JsonResult Create(MyObject myObject) 
    {
      //AllFine
      return Json(new { IsCreated = True, Content = ViewGenerator(myObject));
     
      //Use input may be wrong but nothing crashed
      return Json(new { IsCreated = False, Content = ViewGenerator(myObject));  
       
      //Error
      Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      return Json(new { IsCreated = false, ErrorMessage = 'My error message');
    }
