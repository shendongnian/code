    public void SomeMethod2(int someValue, List<int> someValues)
    {
        Task generatedTask = null;
        {
            var ctx = new MyCaptureContext();
            ctx.anotherValue = 2;
            ctx.valuesRef = someValues;
            ctx.someValue = someValue;
            generatedTask = new Task(ctx.SomeMethod);
        }
        generatedTask.Start();
    }
    class MyCaptureContext
    {
        // kept as fields to mimic the compiler
        public int anotherValue;
        public int someValue;
        public object valuesRef;
        public void SomeMethod()
        {
            anotherValue += someValue + GetSum(valuesRef);
            Console.WriteLine(anotherValue);
        }
    }
