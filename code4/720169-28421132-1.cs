    public class MemberController : RenderMvcController
    {
         [EnsurePublishedContentRequest(2303)]  // 2303 is your node ID
         public ActionResult Index(string query)
         {
             // your code - assign to ViewBag
             return View("~/Views/Member.cshtml", this.CreateRenderModel(Umbraco.TypedContent(2303)));
         }
    }
    private RenderModel CreateRenderModel(IPublishedContent content)
    {
        var model = new RenderModel(content, CultureInfo.CurrentUICulture);
        //add an umbraco data token so the umbraco view engine executes
        RouteData.DataTokens["umbraco-doc-request"] = model;
        return model;
    }
