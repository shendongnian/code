    public Interface ICarModels {
    }
    
    public class Automobile : ICarModels {
       string Color { get; set; }
       string Model { get; set; }
       string Year { get; set; }
       public void AddAccessory(string accessory)
       {
          // Code to Add Accessory
       }
    }
    
    public Interface ICarSales {
    }
    
    public class CarSales : ICarSales {
       public void SellCar()
       {
          // Add code to sell car
       }
       public void LeaseCar()
       {
          // Add code to lease car
       }
    }
