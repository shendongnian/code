    public class HomeController : Controller
    {
       IExportFactory factory;
       public HomeController(IExportFactory factory)
       {
          this.factory = factory;
       }
    
       public void ExportDocument(string content)
       {
          this.factory.CreateNew("html").Run(content);
       }
    }
