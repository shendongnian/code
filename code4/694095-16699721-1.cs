    public interface IGestureListenerFactory
    {
        GestureListener GetGestureListener(int arg);
    }
    public class GestureListenerFactory : IGestureListenerFactory
    {
        private static readonly object Locker = new object();
        private static readonly Dictionary<int, GestureListener> _listener = new Dictionary<int, GestureListener>();
        
        public GestureListener GetGestureListener(int arg)
        {
            GestureListener listener;
            
            if(!_listener.TryGetValue(arg, out listener))
            {
                lock(Locker)
                {
                    if(_listener.ContainsKey(arg))
                        return _listener[arg];
                    listener = new GestureListener(arg);
                    _listener.Add(listener);
                }
            }
            
            return listener;
        }
    }
