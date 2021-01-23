    public static class Helper
    {
        public static bool In<T>(this T t, params T[] args)
        {
          return args.Contains(t);
        }
      }
    }
