        [HttpPost]
		public ActionResult Test(TempModel model)
		{
			ViewBag.Message = "Test: " + model.Id +", " + model.Name;
			return View("About");
		}
    public class TempModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
    routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
