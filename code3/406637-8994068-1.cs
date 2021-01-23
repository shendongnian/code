	public class WidgetController : Controller
	{
		private readonly IRepository<Widget> _repository;
		public WidgetController(IRepository<Widget> repository)
		{
			_repository = repository;
		}
	}
