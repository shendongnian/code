    public abstract class Car
    {
        public abstract double Cost();
    }
    
    public class Mercedes : Car
    {
        public double Cost { get; set; }
        public override double Cost()
        {
            return Cost * 1.2;
        }
    }
    
    public class BMW : Car
    {
        public double Cost { get; set; }
        public override double Cost()
        {
            return Cost * 1.4;
        }
    }
    
    public class Volkswagen : Car
    {
        public double Cost { get; set; }
        public override double Cost()
        {
            return Cost * 1.8;
        }
    }
    
    public class CostEstimation { 
    
       public double Cost(Car[] cars)
       {
        double cost = 0;
        foreach (var car in cars)
        {
            cost += car.Cost();
        }
        return cost;
       }
    }
