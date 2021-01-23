        static void Main(string[] args)
        {
            var garage = new List<Car>();
            //this is where the exception occurs
            garage.Add(new Car(5, "car model"));
        }
        public class Car
        {
            public int VIN { get; set; }
            public int Year { get; set; }
            public string Model { get; set; }
            public Car(int _vin, string _model)
            {
                _vin = VIN;
                _model = Model;
            }
            public Car() { }
            public void Print()
            {
                Console.WriteLine("Here is some information about the car {0} and {1} ");
            }
        }
