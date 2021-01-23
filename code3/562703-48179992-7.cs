    public class Driver : IAutomobile { 
       // Group 1: Sales activities that belong to a salesman
       public void SellCar() { /* no action needed for a driver */ }
       public void BuyCar(); { /* no action needed for a driver */ }
       public void LeaseCar(); { /* no action needed for a driver */ }
    
       // Group 2: Driving activities that belong to a driver
       public void DriveCar() { /* actions to drive car */ }
       public void StopCar(); { /* actions to stop car */ }
    }
