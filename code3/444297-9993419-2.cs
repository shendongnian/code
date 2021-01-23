    public sealed class Val {
      private volatile object boostResult = 0.0;
      public double ThreadSafeDouble {
        set {
            boostResult = value;
        }
        get {
            return (double)boostResult;
        }
      }
    }
