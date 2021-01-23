    internal sealed class ClassA1 : ClassA<ClassA1>
    {
        protected override void MethodACore()
        {
            // Do work here.
            Thread.Sleep(1000);
        }
    }
    internal sealed class ClassA2 : ClassA<ClassA2>
    {
        protected override void MethodACore()
        {
            // Do work here.
            Thread.Sleep(1000);
        }
    }
