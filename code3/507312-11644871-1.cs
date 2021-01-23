    public class HomeController
    {
    	[HttpGet]
    	public ActionResult ValidateUserID(string id)
    	{
    		bool superficialCheck = true;
    		
    		return Json(new { success = superficialCheck },
    			JsonRequestBehavior.AllowGet);
    	}
    }
