    public static class TestClass
    {
        public static double Data;
        public static string StringData = "";
        // Can, and will quite often, return wrong values.
        //  for example returning the result of f(8) instead of f(5)
        //  if Data is changed before StringData is calculated.
        public static string ChangeStaticVariables(int x)
        {
            Data = Math.Sqrt(x) + Math.Sqrt(x);
            StringData = Data.ToString("0.000");
            return StringData;
        }
        // Won't return the wrong values, as the variables
        //  can't be changed by other threads.
        public static string NonStaticVariables(int x)
        {
            var tData = Math.Sqrt(x) + Math.Sqrt(x);
            return Data.ToString("0.000");
        }
    }
