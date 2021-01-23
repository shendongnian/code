	[HttpPost]
	public ActionResult Foo(FooModel model)
	{
		using (var context = new Context())
		{
			var data = context.Foo
				.Where(model.Date != null, x => x.Date == model.Date)
				.Where(model.Name != null, x => x.Name == model.Name)
				.Where(model.ItemCode != null, x => x.ItemCode == model.ItemCode)
				.ToList();
			return View(data);
		}
	}
