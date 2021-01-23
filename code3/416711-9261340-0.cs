    void Start()
    {
        Thread T = new Thread(ThreadMethod);
        T.IsBackground = true;
        T.Start();
    }
    void ThreadMethod()
    {
        string s = System.Console.ReadLine();
        this.Invoke(DoStuffInMain, s);
    }
    void DoStuffInMainThread(string s)
    {
        //
    }
