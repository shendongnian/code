        var car = (Car) null;
        var cat = (Cat) null;
        var house = (House) null;
        using (var carTask = BuyCarAsync())
        using (var catTask = FeedCatAsync())
        using (var houseTask = SellHouseAsync())
        {
            try {
                  await Task.WhenAll(carTask, catTask, houseTask); //or Task.WhenAny(carTask, catTask, houseTask);
            } finally {
                  car = carTask.Status == TaskStatus.RanToCompletion ? await carTask : null;
                  cat = catTask.Status == TaskStatus.RanToCompletion ? await catTask : null;
                  house = houseTask.Status == TaskStatus.RanToCompletion ? await houseTask : null;
            }
            if (cat == null || car == null || house == null)
                throw new SomethingFishyGoingOnHereException("...");
       }
