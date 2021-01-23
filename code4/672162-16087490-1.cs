        class Car {}
        class Toyota : Car {}
        class BMW : Car {}
    
        class User
        {
            private readonly IList<Car> cars = new List<Car>();
            public IList<Car> Cars { get { return cars; } }
            public void AddCar(Car car)
            {
                Cars.Add(car);
            }
        }
        User user1 = new User();
        user1.AddCar(new BMW());
        user1.AddCar(new Toyota());
        User user2 = new User();
        user2.AddCar(new BMW());
        var users = new List<User>
                            {
                                user1,
                                user2
                            };
        IEnumberable<User> usersWithBMW = users.Where(u => u.Cars.Any(c => c is BMW));
