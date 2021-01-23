    public class GestureListenerFActory
    {
        private static readonly object Locker = new object();
        private static readonly Dictionary<int, GestureListener> _listener = new Dictionary<int, GestureListener>();
        
        public GestureListener GetGestureListener(int arg)
        {
            if(_listener.ContainsKey(arg))
            {
                return _listener[arg];
            }
            
            lock(Locker)
            {
                var listener = new GestureListener(arg);
                _listener.Add(listener);
                
                return listener;
            }
        }
    }
