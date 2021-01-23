	    public ActionResult Read([DataSourceRequest]DataSourceRequest request)
		{
			if (ModelState.IsValid)
			{
				var dbViewQuery = context.MyDatabaseView;
				var result = dbViewQuery.ToDataSourceResult(request, r => Mapper.Map<MyViewModelVM>(r));
				return Json(result);
			}
			return Json(new List<MyViewModelVM>().ToDataSourceResult(request));
		}
