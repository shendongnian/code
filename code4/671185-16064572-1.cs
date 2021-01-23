	public JsonResult LongRunningAsyncTask()
	{
		// Show this is async and won't render straight away...
		System.Threading.Thread.Sleep(5000);
		// Build up our view model
		var viewModel = new TestViewModel();
		// Send back as a Json result
		var result = new JsonResult();
		result.Data = viewModel;
		return Json(result, JsonRequestBehavior.AllowGet);
	}
