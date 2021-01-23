    public class MyController : Controller
    {
    public List<T> myList;
     public ActionResult CallToGetThirdPartList(ThirdPartyObject obj)
     {
      list = Session["result"] as SpecialList;
      return View(obj); //important 
     }
     public ActionResult Search(ThirdPartyObject obj) //gets called from jquery 
     {
       var results = from m in myListist   //this is null
                   where m.Title.StartsWith(term)  
                   select new { label = m.Summary, m.id };  
            Session["result"]=results ;
            return Json(results, JsonRequestBehavior.AllowGet)
     }
     }
