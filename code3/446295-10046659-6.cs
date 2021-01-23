    public interface MBuilder {}
    public static class BuilderExtensions {
      public static TBuilder When<TBuilder>(this TBuilder self, bool condition, Action<TBuilder> then, Action<TBuilder> otherwise = null)
      where TBuilder : MBuilder
      {
        if (condition) {
          then(self);
        }
        else if (otherwise != null) {
          otherwise(self);
        }
        return self;
      }
    }
    public class NinjaBuilder : MBuilder ...
