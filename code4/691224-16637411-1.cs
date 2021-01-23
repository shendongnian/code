    public class Accessory
    {
        public string Name{ get; set; }
    }
    class Car
    {
        public string Name { get; set; }
        public IList<Accessory> Accessories { get; set; }
    }
    public static IEnumerable<Car> GetCars(string filterByAccessory, bool sortAscending = true)
    {
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
        var filteredCars = cars.Where(c => c.Accessories.Any(a => a.Name == filterByAccessory));
        var sortedCars = sortAscending
            ? filteredCars.OrderBy(x => x.Name)
            : filteredCars.OrderByDescending(x => x.Name);
        return sortedCars;
    }
