    <form action="~/Search/Index" method="GET">
         ...
         <submit />
    </form>
    class SearchController : Controller
    {
         public ActionResult Index(FilterModel model = null)
         {
             Session["SearchUrl"] = Request.UrlReferrer.ToString();
             var results = get page of results...
             return View(results);
         }
         [HttpPost]
         public ActionResult Edit(EditModel model)
         {
             //update the model...
             return Redirect(Session["SearchUrl"]);
         }
    }
