    public class MyController : Controller
    {
    public List<T> myList;
     public ActionResult CallToGetThirdPartList(ThirdPartyObject obj)
     {
       list = obj.SpecialList;
       Session["list"] = list;
       return View(obj); //important 
     }
     public ActionResult Search(ThirdPartyObject obj) //gets called from jquery 
     {
       var listFromSession = Session["list"] as List<T>;
       var results = from m in listFromSession   //this is null
                   where m.Title.StartsWith(term)  
                   select new { label = m.Summary, m.id };  
            Session["result"]=results ;
            return Json(results, JsonRequestBehavior.AllowGet)
     }
     }
