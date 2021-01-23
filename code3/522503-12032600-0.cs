    enum Cars {
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
      public const Car Corsair = Cars.FordCorsair;
      public const Car Cortina = Cars.FordCortina;
      public const Car Galaxy = Cars.FordGalaxy;
      public const Car GT = Cars.GT;
    }
    public sealed class Ferrari {
      public const Car Testarossa = Cars.FerrariTestarossa;
      public const Car California = Cars.FerrariCalifornia;
      public const Car Enzo = Cars.FerrariEnzo;
      public const Car GT = Cars.GT;
    }
    ...
    Car mycar = Ford.Corsair;
