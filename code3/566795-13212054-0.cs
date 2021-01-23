		private readonly CarsContext _db = new CarsContext();
		public ActionResult Index()
		{
			var result = from cars in _db.CarProfiles
						 where cars.CarOfTheWeek
						 select cars;
			MyViewModel myViewModel = new MyViewModel( );
			myViewModel.Message = "Foobar";
			myViewModel.ResultList = result.ToList();
	
			return View( myViewModel );
		}
