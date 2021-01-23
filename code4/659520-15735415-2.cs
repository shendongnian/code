    class Vehicle
    {
        static ICollection<Vehicle> V;
        
        string Brand;
        string Model;
        int Year;
        int Price;
        static void AddNewVehicle<T>(string brand, string model, int year, int price)
            where T : Vehicle, new()
        {
            V.Add(new T() {
                Brand = brand,
                Model = model,
                Year = year,
                Price = price
            });
        }
    }
