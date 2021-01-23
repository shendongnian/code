    public enum OptimizeFor
    {
        Unspecified,
        Speed,
        Accuracy
    }
    public class EnumParser
    {
        public static IEnumerable<TEnum> FindSelected<TEnum>(IEnumerable<string> enumItemNames)
        {
            var selectedOtions = Enum.GetNames(typeof(TEnum))
                .Intersect(enumItemNames, StringComparer.InvariantCultureIgnoreCase)
                .Select(i => Enum.Parse(typeof(TEnum), i))
                .Cast<TEnum>();
            return selectedOtions;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Some fake arguments
            args = new[] {"-o", "SPEED", "accuracy", "SomethingElse"};
            var selectedEnumVals = EnumParser.FindSelected<OptimizeFor>(args);
            selectedEnumVals.Select(i => i.ToString()).ToList().ForEach(Console.WriteLine);
            Console.Read();
        }
    }
