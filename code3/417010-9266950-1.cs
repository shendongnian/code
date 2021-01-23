	public ActionResult SomeAction(int CarId)
	{
		 using (var repo = CarRepository.BeginUnitOfWork())
		 {
			var car = repo.read(CarId);
			// do something meaningful with the car, do more with the repo, etc.
		 }
	}
