    public void UpdateUser(this User user, User changedUser)
    {
        var changedUserCarIDs = changedUser.Cars.Select(c => c.Id).ToArray();
        user.Cars = user.Cars.Where(c => changedUserCarIDs.Contains(c.Id)).ToList();
        foreach (var changedCar in changedUser.Cars)
        {
            var car = user.Cars.SingleOrDefault(c => c.Id == changedCar.Id);
            if (car == null) user.Cars.Add(car = new Car());
            car.Name = changedCar.Name;
            car.Color = changedCar.Color;
        }
    }
