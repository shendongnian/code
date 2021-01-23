    public static class MyExtensions
    {
        public static string SafeToString(this object obj)
        {
            return (obj ?? "").ToString();
        }
    }
