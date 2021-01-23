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
        
    var usersWithCar = users.Where(x => x.Cars.Any(y => y.Name == "CarName"));
