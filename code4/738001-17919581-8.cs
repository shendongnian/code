    public void SomeMethod(int someValue, List<int> someValues)
    {
        Task generatedTask = null;
        {
            var ctx = new MyCaptureContext();
            ctx.anotherValue = 2;
            ctx.valuesRef = someValues;
            ctx.someValue = someValue;
            generatedTask = ctx.CreateTask();
        }
        generatedTask.Start();
    }
    class MyCaptureContext
    {
        // kept as fields to mimic the compiler
        public int anotherValue;
        public int someValue;
        public object valuesRef;
        public Task CreateTask()
        {
            return new Task(someMethod, this);
        }
        private static readonly Action<object> someMethod = SomeMethod;
        private static void SomeMethod(object state)
        {
            var ctx = (MyCaptureContext)state;
            ctx.anotherValue += ctx.someValue + GetSum(ctx.valuesRef);
            Console.WriteLine(ctx.anotherValue);
        }
    }
