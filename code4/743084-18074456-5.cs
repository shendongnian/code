    class Scope
    {
        public bool IsLocked { get; set; }
        public static implicit operator bool(Scope scope)
        {
            return scope.IsLocked;
        }
    }
    class ScopeGuard : IDisposable
    {
        private Scope _scope;
        public ScopeGuard(Scope scope)
        {
            _scope = scope;
            _scope.IsLocked = true;
        }
        public void Dispose()
        {
            _scope.IsLocked = false;
        }
    }
