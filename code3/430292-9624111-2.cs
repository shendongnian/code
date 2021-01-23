    public class BaseController : Controller   {
        internal void SetSessionData<T>(string name, T value) {            
            this.Session[string.Format("{0}_{1}",value.GetType().GUID,name)] = value;
        }
        internal T GetSessionData<T>(string name) {
            return (T)this.Session[string.Format("{0}_{1}", typeof(T).GUID, name)];
        }
    }
