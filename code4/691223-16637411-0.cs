    public class Accessory
    {
        public string Name{ get; set; }
    }
    class Car
    {
        public string Name { get; set; }
        public IList<Accessory> Accessories { get; set; }
    }
    private IEnumerable<Cars> GetCars()
    {
        string[] sortRules = new string[] { "Breaks", "Airbag", "Radio" };
        var cars = new List<Car>();
        cars.Add(
            new Car()
            {
                Name = "BMW",
                Accessories = new List<Accessory>()
                {
                    new Accessory() { Name = "Radio" },
                    new Accessory() { Name = "Airbag" },
                    new Accessory() { Name = "ABS" },
                    new Accessory() { Name = "ESP" },
                }
            });
        cars.Add(
            new Car()
            {
                Name = "Mazda",
                Accessories = new List<Accessory>()
                {
                    new Accessory() { Name = "Radio" },
                    new Accessory() { Name = "Breaks" },
                }
            });
    
        var sortedCars = sortRules
            .SelectMany(sr => cars.Where(c => c.Accessories.Any(a => a.Name == sr)))
            .Distinct();
        return sortedCars;
    }
