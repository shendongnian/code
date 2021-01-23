    public class PdfCreatorService 
    {
        [Inject]
        public ControllerContextProvider contextProvider { get; set; }
        [Inject]
        public PdfController pdfController { get; set; }
        public override byte[] CreateReport(int reportId)
        {
            var context = contextProvider.GetControllerContext();
            using (var stream = new ResponseCapture(context.RequestContext))
            {
                // Setup Controller
                var routeData = new RouteData(context.RouteData.Route, context.RouteData.RouteHandler);
                routeData.Values.Add("action", "CreateReport");
                routeData.Values.Add("controller", "Pdf");
                routeData.Values.Add("id", reportId);
                var pdfContext = new ControllerContext(context.HttpContext, routeData, pdfController);
                // Execute Controller
                var result = pdfController.CreateReport(reportId);
                result.ExecuteResult(pdfContext);
                return stream.ReadAllContents();
            }
        }
    }
