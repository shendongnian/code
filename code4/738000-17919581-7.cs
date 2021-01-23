    public void SomeMethod(int someValue, List<int> someValues)
    {
        Task generatedTask = null;
        {
            var ctx = new MyCaptureContext();
            ctx.anotherValue = 2;
            ctx.valuesRef = someValues;
            ctx.someValue = someValue;
            generatedTask = new Task(MyCaptureContext.SomeMethod, ctx);
        }
        generatedTask.Start();
    }
    class MyCaptureContext
    {
        // kept as fields to mimic the compiler
        public int anotherValue;
        public int someValue;
        public object valuesRef;
        public static readonly Action<object> SomeMethod = SomeMethodImpl;
        private static void SomeMethodImpl(object state)
        {
            var ctx = (MyCaptureContext)state;
            ctx.anotherValue += ctx.someValue + GetSum(ctx.valuesRef);
            Console.WriteLine(ctx.anotherValue);
        }
    }
