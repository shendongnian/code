    class Program
    {
        static SensEvents SensEvents = new SensEvents();
        static void Main(string[] args)
        {
            SensEvents.LogonEvent += OnSensLogonEvent;
            Console.WriteLine("Waiting for events. Press [ENTER] to stop.");
            Console.ReadLine();
        }
        static void OnSensLogonEvent(object sender, SensLogonEventArgs e)
        {
            Console.WriteLine("Type:" + e.Type + ", UserName:" + e.UserName + ", SessionId:" + e.SessionId);
        }
    }
    public sealed class SensEvents
    {
        private static readonly Guid SENSGUID_EVENTCLASS_LOGON2 = new Guid("d5978650-5b9f-11d1-8dd2-00aa004abd5e");
        private Sink _sink;
        public event EventHandler<SensLogonEventArgs> LogonEvent;
        public SensEvents()
        {
            _sink = new Sink(this);
            COMAdminCatalogClass catalog = new COMAdminCatalogClass(); // need a reference to COMAdmin
            // we just need a transient subscription, for the lifetime of our application
            ICatalogCollection subscriptions = (ICatalogCollection)catalog.GetCollection("TransientSubscriptions");
            ICatalogObject subscription = (ICatalogObject)subscriptions.Add();
            subscription.set_Value("EventCLSID", SENSGUID_EVENTCLASS_LOGON2.ToString("B"));
            subscription.set_Value("SubscriberInterface", _sink);
            // NOTE: we don't specify a method name, so all methods may be called
            subscriptions.SaveChanges();
        }
        private void OnLogonEvent(SensLogonEventType type, string bstrUserName, uint dwSessionId)
        {
            EventHandler<SensLogonEventArgs> handler = LogonEvent;
            if (handler != null)
            {
                handler(this, new SensLogonEventArgs(type, bstrUserName, dwSessionId));
            }
        }
        private class Sink : ISensLogon2
        {
            private SensEvents _events;
            public Sink(SensEvents events)
            {
                _events = events;
            }
            public void Logon(string bstrUserName, uint dwSessionId)
            {
                _events.OnLogonEvent(SensLogonEventType.Logon, bstrUserName, dwSessionId);
            }
            public void Logoff(string bstrUserName, uint dwSessionId)
            {
                _events.OnLogonEvent(SensLogonEventType.Logoff, bstrUserName, dwSessionId);
            }
            public void SessionDisconnect(string bstrUserName, uint dwSessionId)
            {
                _events.OnLogonEvent(SensLogonEventType.SessionDisconnect, bstrUserName, dwSessionId);
            }
            public void SessionReconnect(string bstrUserName, uint dwSessionId)
            {
                _events.OnLogonEvent(SensLogonEventType.SessionReconnect, bstrUserName, dwSessionId);
            }
            public void PostShell(string bstrUserName, uint dwSessionId)
            {
                _events.OnLogonEvent(SensLogonEventType.PostShell, bstrUserName, dwSessionId);
            }
        }
        [ComImport, Guid("D597BAB4-5B9F-11D1-8DD2-00AA004ABD5E")]
        public interface ISensLogon2
        {
            void Logon([MarshalAs(UnmanagedType.BStr)] string bstrUserName, uint dwSessionId);
            void Logoff([In, MarshalAs(UnmanagedType.BStr)] string bstrUserName, uint dwSessionId);
            void SessionDisconnect([In, MarshalAs(UnmanagedType.BStr)] string bstrUserName, uint dwSessionId);
            void SessionReconnect([In, MarshalAs(UnmanagedType.BStr)] string bstrUserName, uint dwSessionId);
            void PostShell([In, MarshalAs(UnmanagedType.BStr)] string bstrUserName, uint dwSessionId);
        }
    }
    public class SensLogonEventArgs : EventArgs
    {
        public SensLogonEventArgs(SensLogonEventType type, string userName, uint sessionId)
        {
            Type = type;
            UserName = userName;
            SessionId = sessionId;
        }
        public string UserName { get; private set; }
        public uint SessionId { get; private set; }
        public SensLogonEventType Type { get; private set; }
    }
    public enum SensLogonEventType
    {
        Logon,
        Logoff,
        SessionDisconnect,
        SessionReconnect,
        PostShell
    }
