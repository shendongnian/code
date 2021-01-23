    public class Salesman : IAutomobile { 
       // Group 1: Sales activities that belong to a salesman
       public void SellCar() { /* Code to Sell car */ }
       public void BuyCar(); { /* Code to Buy car */ }
       public void LeaseCar(); { /* Code to lease car */ }
    
       // Group 2: Driving activities that belong to a driver
       public void DriveCar() { /* no action needed for a salesman */ }
       public void StopCar(); { /* no action needed for a salesman */ }
    }
