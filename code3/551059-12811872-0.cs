    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public BinaryNonBinaryActionResult GetAgreement(string id) 
        { 
            string agreementText = "<FONT color=deepskyblue><STRONG> test text</STRONG></FONT>"; 
            return new BinaryNonBinaryActionResult(GetBytes(agreementText), "text/html"); 
        }
        public byte[] GetBytes(string input)
        {
            string myString = this.RenderViewToString("About", this.ViewData);
            return Encoding.ASCII.GetBytes(myString);
        }
       
    }
---
    public static class RenderExtended
    {
        public static string RenderViewToString(this Controller controller, string viewName, object viewData)
        {
            //Create memory writer     
            var sb = new StringBuilder();
            var memWriter = new StringWriter(sb);
            //Create fake http context to render the view     
            var fakeResponse = new HttpResponse(memWriter);
            var fakeContext = new HttpContext(HttpContext.Current.Request, fakeResponse);
            var fakeControllerContext = new ControllerContext(new HttpContextWrapper(fakeContext), controller.ControllerContext.RouteData, controller.ControllerContext.Controller);
            var oldContext = HttpContext.Current;
            HttpContext.Current = fakeContext;
            
            //Use HtmlHelper to render partial view to fake context     
            var html = new HtmlHelper(new ViewContext(fakeControllerContext, new FakeView(), new ViewDataDictionary(), new TempDataDictionary(), memWriter), new ViewPage());
            html.RenderPartial(viewName, viewData);
            //Restore context     
            HttpContext.Current = oldContext;
            //Flush memory and return output     
            memWriter.Flush();
            return sb.ToString();
        }
        public class FakeView : IView
        {
            public void Render(ViewContext viewContext, System.IO.TextWriter writer)
            {
                throw new NotImplementedException();
            }
        }
    }
