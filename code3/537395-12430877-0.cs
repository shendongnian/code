    public interface IOutHttpContext {
        object GetSessionVar( string key );
        void SetSessionVar( string key, object value );
    }
    public class OurDotNetHttpContext : IOutHttpContext {
        public object GetSessionVar(string key) { return HttpContext.Current.Session[key]; }
        public void SetSessionVar(string key, object value) { HttpContext.Current.Session[key] = value; }
    }
