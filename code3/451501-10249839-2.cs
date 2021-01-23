    [Serializable]
    public class PreventEventHookedTwiceAttribute: EventInterceptionAspect
    {
        private readonly object _lockObject = new object();
        readonly List<Delegate> _delegates = new List<Delegate>();
    
        public override void OnAddHandler(EventInterceptionArgs args)
        {
            lock(_lockObject)
            {
                if(!_delegates.Contains(args.Handler))
                {
                    _delegates.Add(args.Handler);
                    args.ProceedAddHandler();
                }
            }
        }
    
        public override void OnRemoveHandler(EventInterceptionArgs args)
        {
            lock(_lockObject)
            {
                if(_delegates.Contains(args.Handler))
                {
                    _delegates.Remove(args.Handler);
                    args.ProceedRemoveHandler();
                }
            }
        }
    }
