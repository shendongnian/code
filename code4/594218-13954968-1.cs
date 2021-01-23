    public static class OptionExtensions {
      public static T? GetNullableValue<T>(this Option<T> option) where T : struct {
        return option.HasValue ? (T?)option.Value : null;
      }
      public static T GetValueOrNull<T>(this Option<T> option) where T : class {
        return option.HasValue ? option.Value : null;
      }
    }
