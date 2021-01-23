	using System.Collections.Generic;
	using System.Web.Mvc;
	namespace MvcApplication1.Controllers
	{
		public class MyController : Controller
		{
			public ActionResult MyAction(MyModel Model)
			{
				return View(Model);
			}
		}
		public class MyModel
		{
			public List<string> TextFields { get; set; }
		}
	}
