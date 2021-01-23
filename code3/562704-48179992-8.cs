    Interface ISales { 
       public void SellCar();
       public void BuyCar();
       public void LeaseCar();
    }
    
    Interface IDrive {
       public void DriveCar();
       public void StopCar(); 
    }
    public class Salesman : ISales { 
       public void SellCar() { /* Code to Sell car */ }
       public void BuyCar(); { /* Code to Buy car */ }
       public void LeaseCar(); { /* Code to lease car */ }
    }
    
    public class Driver : IDrive { 
       public void DriveCar() { /* actions to drive car */ }
       public void StopCar(); { /* actions to stop car */ }
    }
