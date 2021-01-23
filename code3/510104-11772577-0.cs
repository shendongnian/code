    public class MyJobProcessor : DisposeNotifyingObject, IRegisteredObject
    {
        public void Execute() { ... }
        public void Stop(bool immediate) { ... }
    }
