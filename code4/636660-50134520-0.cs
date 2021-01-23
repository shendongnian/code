    private static System.Threading.Mutex _mutex = null;
    protected override void OnStartup(StartupEventArgs e)
    {
        string mutexId = ((System.Runtime.InteropServices.GuidAttribute)System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false).GetValue(0)).Value.ToString();
        _mutex = new System.Threading.Mutex(true, mutexId, out bool createdNew);
        if (!createdNew) Current.Shutdown();
        else Exit += CloseMutexHandler;
        base.OnStartup(e);
    }
    protected virtual void CloseMutexHandler(object sender, EventArgs e)
    {
        _mutex?.Close();
    }
