    void Application_BeginRequest(Object source, EventArgs e)
    {
        HttpApplication app = (HttpApplication)source;
        HttpContext context = app.Context;
    
        // Attempt to peform first request initialization
        FirstRequestInitialization.Initialize(context);
    }
    
    
    class FirstRequestInitialization
    {
        private static bool s_InitializedAlready = false;
        private static Object s_lock = newObject();
    
        // Initialize only on the first request
        publicstaticvoid Initialize(HttpContext context)
        {
            if (s_InitializedAlready)
                return;
    
            lock (s_lock)
            {
                if (s_InitializedAlready)
                    return;
    
                /* << Perform first-request initialization here >> */
                s_InitializedAlready = true;
            }
        }
    }
