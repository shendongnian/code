    enum Car {
      FordCorsair,
      FordCortina,
      FordGalaxy,
      FordGT,
      FerrariTestarossa,
      FerrariCalifornia,
      FerrariEnzo,
      ...
    }
    public sealed class Ford {
      public const Car Corsair = Car.FordCorsair;
      public const Car Cortina = Car.FordCortina;
      public const Car Galaxy = Car.FordGalaxy;
      public const Car GT = Car.GT;
    }
    public sealed class Ferrari {
      public const Car Testarossa = Car.FerrariTestarossa;
      public const Car California = Car.FerrariCalifornia;
      public const Car Enzo = Car.FerrariEnzo;
      public const Car GT = Car.GT;
    }
    ...
    Car mycar = Ford.Corsair;
