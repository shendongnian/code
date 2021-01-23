    public class MessageWrapper
    {
        readonly object _gate = new object();
        int? _pendingB;
        public Message WrapA(int a, int millisecondsTimeout)
        {
            int? currentB;
            lock (_gate)
            {
                currentB = _pendingB;
                _pendingB = null;
                Monitor.Pulse(_gate); // B stolen, get rid of waiting threads
            }
            return new Message(a, currentB);
        }
        public Message WrapB(int b, int millisecondsTimeout)
        {
            lock (_gate)
            {
                if (_pendingB != null)
                {
                    var currentB = _pendingB;
                    _pendingB = b;
                    Monitor.Pulse(_gate); // release for fairness
                    Monitor.Wait(_gate, millisecondsTimeout); // wait for fairness
                    return new Message(null, currentB);
                }
                else
                {
                    _pendingB = b;
                    Monitor.Pulse(_gate); // release for fairness
                    Monitor.Wait(_gate, millisecondsTimeout); // wait for A
                    if (_pendingB == null) return null;
                    var currentB = _pendingB;
                    _pendingB = null;
                    return new Message(null, currentB);
                }
            }
        }
    }
