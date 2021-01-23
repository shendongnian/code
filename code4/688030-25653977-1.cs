      public class Vehicle
      {
        public int NumWheels { get; set; }
        public bool HasMotor { get; set; }
      }
    
      public class Car: Vehicle
      {
        public string Color { get; set; }
        public string SteeringColumnStyle { get; set; }
      }
    
      public class CarMaker
      {
        // I am given vehicles that I want to turn into cars...
        public List<Car> Convert(List<Vehicle> vehicles)
        {
          var cars = new List<Car>();
          AutoMapper.Mapper.CreateMap<Vehicle, Car>(); //declare that we want some automagic to happen
          foreach (var vehicle in vehicles)
          {
            var car = AutoMapper.Mapper.Map<Car>(vehicle);
            // At this point, the car-specific properties (Color and SteeringColumnStyle) are null, because there are no properties in the Vehicle object to map from.
            // However, car's NumWheels and HasMotor properties which exist due to inheritance, are populated by AutoMapper.
            cars.Add(car);
          }
          return cars;
        }
      }
