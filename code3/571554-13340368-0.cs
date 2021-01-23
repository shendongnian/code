    public class Garage : IEnumerable
    {
      public Car this[int i]
      {
        return this.cars[i];
      }
    }
