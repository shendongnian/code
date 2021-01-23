    public static class DoubleArrayExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.       
        public static double Last(this double[] items)
        {
            return items[items.Length - 1];
        }
    }
