    public class SomeJobFactory : Factory<IJob>
    {
       public bool MeetsCondition() { ... }
       public IJob CreateInstance() { return new SomeJob(); }
    }
