    public class ContentsController : BaseController
    {
      private readonly IContentService service;
      public ContentsController(IContentService service)
      {
        if(service == null) throw new ArgumentNullException("service");
        this.service = service;
      }
    }
    
    var container = new UnityContainer();
    container.RegisterType<IContentService, MyContentService>();
    var controller = container.Resolve<ContentsController>();
