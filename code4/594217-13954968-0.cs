    public static class OptionExtensions {
      public static T? ToNullable<T>(this Option<T> option) where T : struct {
        return option.HasValue ? (T?)option.Value : null;
      }
    }
