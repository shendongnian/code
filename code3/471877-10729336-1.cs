    public class Client {
      public double Weight { get; }
    
      public double Height { get; }
    }
    
    public interface TClientWeight {
      double Weight { get; }
    }
    
    public interface TClientHeight {
      double Height { get; }
    }
    
    public class ClientA: Client, TClientWeight { }
    
    public class ClientB: Client, TClientHeight { }
    
    public class ClientC: Client, TClientWeight, TClientHeight { }
    
    public static class TClientWeightMethods {
      public static bool IsHeavierThan(this TClientWeight client, double weight) {
        return client.Weight > weight;
      }
      // add more methods as you see fit
    }
    public static class TClientHeightMethods {
      public static bool IsTallerThan(this TClientHeight client, double height) {
        return client.Height > height;
      }
      // add more methods as you see fit
    }
