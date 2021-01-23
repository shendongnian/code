    public static class features
    {
        public enum TYPES { favorite, nice }
        public static Dictionary<TYPES,string> values = new Dictionary<TYPES,string>() {
             { TYPES.favorite, "blue background" },
             { TYPES.nice, "animation" } };
    }
    public static class Program
    {
        public static void Main()
        {
           foreach (string feature in features.values.keys)
           {
               Console.WriteLine(features.values[feature]);
           }
           //... select a feature
           Console.WriteLine(features.values[TYPES.favorite]);
      }
}
