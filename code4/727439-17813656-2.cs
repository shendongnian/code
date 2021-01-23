    class _SomethingAnonymous : IFooFactory
    {
        readonly IResolutionRoot _resolutionRoot; 
        public _SomethingAnonymous(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot=resolutionRoot; 
        }
        IFoo CreateFoo() 
        { 
             _resolutionRoot.Get<IFoo>();
        }
     }
