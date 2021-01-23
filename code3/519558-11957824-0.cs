    List<Car> cars = new List<Car>() {  new Car() { Name = "Ford", Year = 1892, Website = "www.ford.us" }, 
                                        new Car() { Name = "Jaguar", Year = 1892, Website = "www.jaguar.co.uk" }, 
                                        new Car() { Name = "Honda", Year = 1892, Website = "www.honda.jp"} };
    List<Factory> factories = new List<Factory>() {     new Factory() { Name = "Ferrari", Website = "www.ferrari.it" }, 
                                                        new Factory() { Name = "Jaguar", Website = "www.jaguar.co.uk" }, 
                                                        new Factory() { Name = "BMW", Website = "www.bmw.de"} };
    foreach (Car car in cars.Where(c => !factories.Any(f => f.Name == c.Name))) {
        lblDebug.Text += car.Name;
    }
