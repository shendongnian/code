    public class MyProxy : IProxiedInterface
    {
        private IProxiedInterface _Target;
        public MyProxy(IProxiedInterface target)
        {
            if(target == null)
                throw new ArgumentNullException("target");
            _Target = target;
        }
        // ToDo: Implement all functions from IProxiedInterface
        //       and delegate them to the target
        public bool DoSomething()
        {
            return _Target.DoSomething();
        }
    }
