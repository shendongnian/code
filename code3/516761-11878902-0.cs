    public Task<string> LoadMyPage()
    {
        return Task<string>.Factory.StartNew(() =>
                                                    {
                                                        Sleep(3000);
                                                        return "Hello world";
                                                    });
    }
    static void Sleep(int ms)
    {
        new ManualResetEvent(false).WaitOne(ms);
    }
