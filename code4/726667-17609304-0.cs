    [HttpPost]
            public ActionResult UploadItem()
            {
                var httpPostedFileBase = Request.Files[0];
                if (httpPostedFileBase != null && httpPostedFileBase.ContentLength != 0)
                {
                    //save file in server and return a string 
    		return Content("Ok");
                }
                else
                {
                   return Content("Failed")
                }
        }
