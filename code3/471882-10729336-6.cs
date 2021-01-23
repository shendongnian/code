    public class Client: DynamicObject { /* implementation see above */ }
    public interface TClientWeight, IDynamicObject {
      double Weight { get; }
    }
    public class ClientA: Client, TClientWeight { }
    public static class TClientWeightMethods {
      public static bool HasWeightChanged(this TClientWeight client) {
        object oldWeight;
        bool result = client.TryGetAttribute("oldWeight", out oldWeight) && client.Weight.Equals(oldWeight);
        client.SetAttribute("oldWeight", client.Weight);
        return result;
      }
      // add more methods as you see fit
    }
