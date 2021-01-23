    //using System.Runtime.CompilerServices;
    private static volatile Singelton _instance;
    public static Singelton Instance
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            if (_instance == null)
            {
                _instance = new Singelton();
            }
            return _instance;
        }
    }
