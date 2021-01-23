     public JsonResult Method()
     {
       return Json(new JsonResult()
          {
             Data = "Result"
          }, JsonRequestBehavior.AllowGet);
     }
