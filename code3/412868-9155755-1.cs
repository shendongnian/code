    public class MockHttpSession : HttpSessionStateBase
    {
        Dictionary<string, object> sessionStorage = new Dictionary<string, object>();
    
        public override object this[string name]
        {
            get { return sessionStorage[name]; }
            set { sessionStorage[name] = value; }
        }
    }
