    public class APIClass
    {
        [Obsolete("Obsolete in v2.0")]
        private event EventHandler ObsoleteEvent;
        [Obsolete("Obsolete in v2.0")]
        public void AddListener(EventHandler eh)
        {
            ObsoleteEvent += eh;
        }
    }
    private static void SubscribeToEvent(APIClass apiClass)
    {
        //apiClass.ObsoleteEvent += delegate { };
        apiClass.AddListener(delegate { });
    }
