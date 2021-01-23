    // I am the generated POCO form the Entity Model
    public class Car
    {
        public string IdLang { get; set; }
        public string IdCompany { get; set; }
    }
    
    // I am a class for just 'get' methods or update methods potentially
    public class GetData
    {
         // I am returning a single Entity of 'Car' type based on predicate
         public Car returnSpecificCar(string aLanguage)
        {
            using (EntityName e = new EntityName())
            {
                // I like lambda methods better due to less lines
                return e.Car.FirstOrDefault(n => n.Language == aLanguage);
                // Similar method in Linq style
                // return (from c in e.Car where c.Language == aLanguage
                // select c).FirstOrDefault();
            }
        }
        // I return all cars
        public List<Car> returnAllCars()
        {
            using (EntityName e = new EntityName())
            {
                return e.Car.ToList();
            }
        }
    }
    
    // Simple console example
    class Program
    {
        static void Main(string[] arts)
        {
            GetData d = new GetData();
            var cars = d.returnEntites();
            var specCar1 = d.returnSpecificEntities("EN");
            var specCar2 = d.returnSpecificEntities("DE");
            string ln = "-----All cars----" + Environment.NewLine;
            cars.ForEach(c => ln += c.CarId + "\t" + c.CarName + Environment.NewLine);
            ln += Environment.NewLine + Environment.NewLine + "----Specific Car1 -----" + Environment.NewLine;
            ln += specCar1.CarID + "\t" + specCar1.CarName+ Environment.NewLine;
            ln += Environment.NewLine + Environment.NewLine + "----Specific Car2 -----" + Environment.NewLine;
            ln += specCar2.CarID + "\t" + specCar2.CarName + Environment.NewLine;
            Console.WriteLine(ln);
            Console.ReadLine();
        }
    }
