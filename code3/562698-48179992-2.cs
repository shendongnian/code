    public class Mercedes { 
       public double Cost { get; set; } 
    } 
    
    public class CostEstimation { 
       public double Cost(Mercedes[] cars) { 
         double cost = 0; 
         foreach (var car in cars) { 
            cost += car.Cost; } return cost; } 
    }
