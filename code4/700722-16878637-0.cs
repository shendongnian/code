    public class ParentClass
    {
        protected abstract void Handler1();
        ...
        protected abstract void HandlerN();
    }
    public class Session : ParentClass, ISessionGraphTransitionHandler
    {
        private void Handler1();
        ...
        private void HandlerN();
    }
