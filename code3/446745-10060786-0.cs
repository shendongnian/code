    public class RoomCache
    {
        private ConcurrentDictionary<string, List<string>> _dicOnlineTraders;
        ILoggingService _logService = new LoggingService();
        private static readonly object SynchronousReadLock = new object();
        // This is bad because the reference is passed out to the
        // caller and we can't be sure that callers will behave. Any
        // modifications to that list will change our list too.
        private List<string> GetOnlineTradersWithSideEffects(string sRoom)
        {
            List<string> theseTraders = null;
            _dicOnlineTraders.TryGetValue(sRoom, out theseTraders);
            return theseTraders; 
        }
        // A side-effect-free method of returning the list to a caller.
        private List<string> GetOnlineTraders(string sRoom)
        {
            List<string> theseTraders = null;
            _dicOnlineTraders.TryGetValue(sRoom, out theseTraders);
            lock (SynchronousReadLock)
            {
                // Create a new list to return to a caller, that has 
                // copies of the elements of the list in the dictionary.
                var localCopy = new List<string>(theseTraders);
                return localCopy;
            }
        }
            
        public RoomCache()
        {
            _dicOnlineTraders = new ConcurrentDictionary<string, List<string>>();
        }
        public void UpdateTraderCurrentRoom(string sRoom, string sTrader)
        {
            _dicOnlineTraders.AddOrUpdate(sRoom, new List<string>() { sTrader }, (x, y) => {});
        }
        private List<string> UpdateRoomOnlineTraderList(string sTrader, List<string> aryTraderList)
        {
            try
            {
                // Lock here too, when modifying the list so that our reads 
                // wait for writes and vice-versa.
                lock (SynchronousReadLock)
                {
                    if (!aryTraderList.Contains(sTrader))
                        aryTraderList.Add(sTrader);
                    return aryTraderList;
                }
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                return aryTraderList;
            }
        }
    }
