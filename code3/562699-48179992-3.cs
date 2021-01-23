    public class CostEstimation { 
       public double Cost(object[] cars)
       {
          double cost = 0;
          foreach (var car in cars)
          {
            if (car is Mercedes)
            {
                Mercedes mercedes = (Mercedes) car;
                cost += mercedes.cost;
            }
            else if (car is Volkswagen)
            {
                Volkswagen volks = (Volkswagen)car;
                cost += volks.cost;
            }
          }
          return cost;
       }
    }
