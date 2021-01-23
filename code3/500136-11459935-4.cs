    public class FooActionMethods<TFoo>
    {
        public static void DoSomething(TFoo foo)
        {
            int i = 0;
            int number = (int)typeof(TFoo).GetMethod("GetNumber").Invoke(foo, null);
            Console.WriteLine(i + number);
        }
    }
