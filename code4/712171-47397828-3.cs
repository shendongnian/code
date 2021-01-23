      public async Task<string> Foobar() {
		async Task<string> Awaited(Task<Cat> a, Task<House> b, Task<Tesla> c) {
			return DoSomething(await a, await b, await c);
		}
	  
        using (var carTask = BuyCarAsync())
        using (var catTask = FeedCatAsync())
        using (var houseTask = SellHouseAsync())
        {
			if (carTask.Status == TaskStatus.RanToCompletion //triple
				&& catTask.Status == TaskStatus.RanToCompletion //cache
				&& houseTask.Status == TaskStatus.RanToCompletion) { //hits
				return Task.FromResult(DoSomething(catTask.Result, carTask.Result, houseTask.Result)); //fast-track
			}
			cat = await catTask;
            car = await carTask;
			house = await houseTask;
			//or Task.AwaitAll(carTask, catTask, houseTask);
			//or await Task.WhenAll(carTask, catTask, houseTask);
            //it depends on how you like exception handling better
				
			return Awaited(catTask, carTask, houseTask);
       }
	 }
