    public void Method<T>(Context context, EventLog log = null) where T : BaseAPICall
    {
        Class myClass = ConvertToMyClass();
        T apiCall = (T)Activator.CreateInstance(typeof(T), new object[] { context });
        if (log != null)
        {
            eventLog.WriteEntry("Starting");
        }
        try
        {
            apiCall.Call(myClass, null, false);
            IsCallSuccess = true;
        }
        catch (Exception e)
        {
            if (log != null)
            {
                eventLog.WriteEntry("error");
            }
            IsCallSuccess= false;
            CallErrorMessage = e.Message;
        }
    }
