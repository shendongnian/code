    public class Test
    {
        static string firstname;
        public static Expression<Func<string, bool>> exp2 = s => s.Contains(firstname);
    }
