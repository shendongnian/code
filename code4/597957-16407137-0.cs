    public static class Visitor
    {
        /// <summary>
        /// Create <see cref="IActionVisitor{TBase}"/>.
        /// </summary>
        /// <typeparam name="TBase">Base type.</typeparam>
        /// <returns>New instance of <see cref="IActionVisitor{TBase}"/>.</returns>
        public static IActionVisitor<TBase> For<TBase>()
            where TBase : class
        {
            return new ActionVisitor<TBase>();
        }
    
        private sealed class ActionVisitor<TBase> : IActionVisitor<TBase>
            where TBase : class
        {
            private readonly Dictionary<Type, Action<TBase>> _repository =
                new Dictionary<Type, Action<TBase>>();
    
            public void Register<T>(Action<T> action)
                where T : TBase
            {
                _repository[typeof(T)] = x => action((T)x);
            }
    
            public void Visit<T>(T value)
                where T : TBase
    
            {
                Action<TBase> action = _repository[value.GetType()];
                action(value);
            }
        }
    }
      public interface IActionVisitor<in TBase>
            where TBase : class
    {
        void Register<T>(Action<T> action)
            where T : TBase;
    
        void Visit<T>(T value)
            where T : TBase;
    }
