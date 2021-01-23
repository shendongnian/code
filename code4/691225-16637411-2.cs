    private static IEnumerable<Car> GetCars(string filterByAccessory, bool sortAscending = true)
    {
        var cars = new List<Car>();
        cars.Add(
            new Car()
            {
                Name = "CAR1",
                Accessories = new List<Accessory>()
            {
                new Accessory() { Name = "ABS Brakes", Value = "1" },
                new Accessory() { Name = "Airbag", Value = "1" },
                new Accessory() { Name = "Climate Control", Value = "1" },
                new Accessory() { Name = "Heated Seats", Value = "1" },
                new Accessory() { Name = "HID Xenon Headlights", Value = "1" },
                new Accessory() { Name = "Radio", Value = "1" },
                new Accessory() { Name = "Quattro", Value = "0" },
                new Accessory() { Name = "Sat/Nav", Value = "1" },
                new Accessory() { Name = "Side Assist", Value = "0" },
                new Accessory() { Name = "Name", Value = "BMW" },
            }
            });
        cars.Add(
            new Car()
            {
                Name = "CAR2",
                Accessories = new List<Accessory>()
            {
                new Accessory() { Name = "ABS Brakes", Value = "1" },
                new Accessory() { Name = "Airbag", Value = "1" },
                new Accessory() { Name = "Climate Control", Value = "1" },
                new Accessory() { Name = "Heated Seats", Value = "0" },
                new Accessory() { Name = "HID Xenon Headlights", Value = "0" },
                new Accessory() { Name = "Radio", Value = "1" },
                new Accessory() { Name = "Quattro", Value = "0" },
                new Accessory() { Name = "Sat/Nav", Value = "0" },
                new Accessory() { Name = "Side Assist", Value = "0" },
                new Accessory() { Name = "Name", Value = "Mazda" },
            }
            });
        cars.Add(
            new Car()
            {
                Name = "CAR3",
                Accessories = new List<Accessory>()
            {
                new Accessory() { Name = "ABS Brakes", Value = "1" },
                new Accessory() { Name = "Airbag", Value = "1" },
                new Accessory() { Name = "Climate Control", Value = "1" },
                new Accessory() { Name = "Heated Seats", Value = "1" },
                new Accessory() { Name = "HID Xenon Headlights", Value = "1" },
                new Accessory() { Name = "Radio", Value = "1" },
                new Accessory() { Name = "Quattro", Value = "1" },
                new Accessory() { Name = "Sat/Nav", Value = "1" },
                new Accessory() { Name = "Side Assist", Value = "1" },
                new Accessory() { Name = "Name", Value = "Audi" },
            }
            });
        var filteredCars = cars.Where(c => c.Accessories.Any(a => a.Name == filterByAccessory));
        var sortedCars = sortAscending
            ? filteredCars.OrderBy(x => x.Accessories.First(a => a.Name == filterByAccessory).Value)
            : filteredCars.OrderByDescending(x => x.Accessories.First(a => a.Name == filterByAccessory).Value);
        return sortedCars;
    }
