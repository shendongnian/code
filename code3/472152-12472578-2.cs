    void Application_Start(object sender, EventArgs e) 
    {
        System.Reflection.PropertyInfo p = typeof(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        object o = p.GetValue(null, null);
        System.Reflection.FieldInfo f = o.GetType().GetField("_dirMonSubdirs", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.IgnoreCase);
        object monitor = f.GetValue(o);
        System.Reflection.MethodInfo m = monitor.GetType().GetMethod("StopMonitoring", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        m.Invoke(monitor, new object[] { }); 
    }
