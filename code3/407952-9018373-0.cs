    public interface IServiceOneFactory
    {
        ISingletonServiceOne Create(object requester);
    }
    
    public static class MyExtensions
    {
        public static IServiceOneFactory ServiceOneFactory
        {
            get 
            {
                if( _ServiceOneFactory==null)
                    _ServiceOneFactory = ServiceLocator.GetService<IServiceOneFactory>();
                return _ServiceOneFactory;
            }
            set { _ServiceOneFactory = value; }
        }
    
        private static IServiceOneFactory _ServiceOneFactory = null;
        private static ISingletonServiceOne _ServiceOne = null;
        private static ISingletonServiceTwo _ServiceTwo = null; // etc ... 
    
        public static SummaryHeader GetBannerSummary(this IModel rfq, object requester)
        {
            Guard.ArgumentNotNull(rfq, "rfq");
            Guard.ArgumentNotNull(requester, "requester");
    
            if (_ServiceOne == null)
            {
                _ServiceOne = ServiceOneFactory.Create(requester);
                Guard.ArgumentNotNull(_ServiceOne, "_ServiceOne");
            }
    
            return _ServiceOne.GetBannerSummary(rfq);
        }
    }
