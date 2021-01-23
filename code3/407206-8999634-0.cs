    public class Test
    {   
      public static bool IsEmpty(params string []args)
        {
            if (args.Length == 0) return true ;
            return args.Any(p => string.IsNullOrEmpty(p));
        }
    }
