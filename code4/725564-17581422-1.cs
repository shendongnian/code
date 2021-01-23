	[Export]
	[PartCreationPolicy( CreationPolicy.NonShared )]
	public partial class HomeController : ControllerCore
	{
		[ImportingConstructor]
		public HomeController( DataContext context, ILogFactory logFactory, ServiceFactory serviceFactory ) : base( context, logFactory, serviceFactory )
		{
		}
		public virtual ActionResult Index()
		{
			return View();
		}
	}
