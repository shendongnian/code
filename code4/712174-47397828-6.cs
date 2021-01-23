     public async Task<string> Foobar() {
        using (var carTask = BuyCarAsync())
        using (var catTask = FeedCatAsync())
        using (var houseTask = SellHouseAsync())
        {
			cat = catTask.Status == TaskStatus.RanToCompletion ? catTask.Result : (await catTask);
            car = carTask.Status == TaskStatus.RanToCompletion ? carTask.Result : (await carTask);
			house = houseTask.Status == TaskStatus.RanToCompletion ? houseTask.Result : (await houseTask);
			
            return DoSomething(cat, car, house);
         }
	 }
