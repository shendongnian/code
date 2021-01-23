    public interface IFluentApi {}
    public interface IFoo<T> {}
    
    public interface IBar<T> {}
    
    public struct Unit {}
    public static class Extenders
    {
        public static IFoo<Unit> Foo(this IFluentApi api, Action action) {return null;}
        public static IFoo<T> Foo<T>(this IFluentApi api, Func<T> func) {return null;}
        public static IBar<T> Bar<T>(this IFoo<T> foo) {return null;}
        public static void FooBar<T>(this IBar<T> bar, Action action) {}
        public static void FooBar<T>(this IBar<T> bar, Action<T> action) {}
        public static void CheckType<T>(this T value) {}
    }
    public class Examples
    {
        public void Example()
        {
            
            IFluentApi api = null;
            api.Foo(() => "Value")
               .Bar()
               .FooBar(x => x.CheckType<string>()); // x is a string
            api.Foo(() => {})
               .Bar()
               .FooBar(x => x.CheckType<Unit>() ); // x is a Unit
            // The following (correctly) fails to type check
            Action<string> stringAction = Console.WriteLine;
            api.Foo(() => (long) 7)
               .Bar()
               .FooBar(stringAction); // x should be of type long
        }
    }
