    public static class ConvertHelper
    {
        public static T ChangeType<T>(string value)
        {
          return (T)Convert.ChangeType(value, typeof(T));
        }
    }
    ...
    int x = ConvertHelper.ChangeType<int>(v);
