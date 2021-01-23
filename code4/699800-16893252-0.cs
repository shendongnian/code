    public sealed class CentralLogic
    {
        private static readonly Lazy<CentralLogic> lazy =
            new Lazy<CentralLogic>(() => new CentralLogic());
        
        public static CentralLogic Instance { get { return lazy.Value; } }
    
        private CentralLogic()
        {
        }
    }
