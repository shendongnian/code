    class Users
    {
        public string Name { get; set; }
        
        public List<Car> Cars { get; set; }
    }
        
    class Car
    {
        public string Name { get; set; }
    }
        
    var users = new List<Users>
                        {
                            new Users
                                {
                                    Name = "Bob",
                                    Cars = new List<Car> { new Car { Name = "Toyota" } }
                                }
                        };
    
    // Any Cars with Name "Toyota" in a User's list of cars.    
    var usersWithCar = users.Where(user => user.Cars.Any(car => car.Name == "Toyota"));
    
    string userName = usersWithCar.Single().Name; // Bob
