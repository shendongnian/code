    public static class Validate
    {
        public static IArgument<T> Argument<T>(string name, T value)
        {
            return new Argument<T>(name, value);
        }
    }
    public interface IArgument<out T>
    {
        string Name { get; }
        T Value { get; }
    }
    public class Argument<T> : IArgument<T>
    {
        internal Argument(string name, T value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; private set; }
        public T Value { get; private set; }
    }
    public static class ExtensionMethods
    {
        public static IArgument<T> IsNotNull<T>(this IArgument<T> argument)
        {
            return argument;
        }
        public static IArgument<IEnumerable<T>> HasItems<T>(this IArgument<IEnumerable<T>> argument)
        {
            return argument;
        }
        public static IArgument<IEnumerable<T>> All<T>(this IArgument<IEnumerable<T>> argument, Predicate<T> predicate)
        {
            return argument;
        }
    }
    
    [TestMethod]
    public void TestMethod1()
    {
        List<int> argument = new List<int>() { 1, 2, 6, 3, -1, 5, 0 };
        Validate.Argument("argument", argument)
            .IsNotNull()
            .HasItems()
            .All(v => v > 0);
    }
