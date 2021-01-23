    public class BaseAPICall
    {
        public abstract Call(Class c, object o, bool b);
        public virtual Method(Context context, EventLog log = null)
        {
            Class myClass = ConvertToMyClass();
            if (log != null)
            {
                eventLog.WriteEntry("Starting");
            }
            try
            {
                this.Call(myClass, null, false);
                IsCallSuccess = true;
            }
            catch (Exception e)
            {
                if (log != null)
                {
                    eventLog.WriteEntry("error");
                }
                IsCallSuccess = false;
                CallErrorMessage = e.Message;
            }
        }
    }
