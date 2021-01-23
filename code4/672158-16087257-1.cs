    class Users
    {
        public string Name { get; set; }
        
        public List<Car> Cars { get; set; }
    }
        
    class Car
    {
        public string Name { get; set; }
    }
        
    var users = new List<Users>();
        
    var usersWithCar = users.Where(user => user.Cars.Any(car => car.Name == "CarName"));
