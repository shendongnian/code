      public interface IActionVisitor<in TBase>
            where TBase : class
    {
        void Register<T>(Action<T> action)
            where T : TBase;
    
        void Visit<T>(T value)
            where T : TBase;
    }
