    [HttpGet]
    public JsonResult Images()
    {
    	var image1Base64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(Server.MapPath("~/Images/1.jpg")));
    	var image2Base64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(Server.MapPath("~/Images/2.jpg")));
    
    	var jsonResult = Json(new { image1 = image1Base64, image2 = image2Base64 }, JsonRequestBehavior.AllowGet);
    	jsonResult.MaxJsonLength = int.MaxValue;
    			
    	return jsonResult;
    }
