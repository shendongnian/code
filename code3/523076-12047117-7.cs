    public class Parent : IDisposable
    {
        public Parent() { Debug.WriteLine("Parent()"); }
        public virtual void Dispose() { Debug.WriteLine("Parent.Dispose()"); }
        ~Parent() { Debug.WriteLine("~Parent()"); }
    }
    public class Child : Parent
    {
        public Child() { Debug.WriteLine("Child()"); throw new Exception(); }
        public override void Dispose() { Debug.WriteLine("Child.Dispose()"); }
        ~Child() { Debug.WriteLine("~Child()"); }
    }
    try
    {
        Object o = new Child();
    }
    catch (Exception e)
    {
        Debug.WriteLine("Exception Caught");
        Debug.WriteLine("GC::Collect()");
        GC.Collect();
        Debug.WriteLine("GC::WaitForPendingFinalizers()");
        GC.WaitForPendingFinalizers();
        Debug.WriteLine("GC::Collect()");
        GC.Collect();
        return;
    }
