    public static class Extensions
    {
        public static double ToDoubleIfNotDBNull(this object item)
        {
           if (item is DBNULL) return 0;
           return double.Parse(item.ToString());
        }
    }
