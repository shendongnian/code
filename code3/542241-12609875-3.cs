    ////It appears that DrawText always calls DrawTextEx so it is getting intercepted twice.
    //// Only need to hook DrawTextEx
    static EasyHook.LocalHook _drawTextExAHook;
    
    //Snip...
    public override void Run()
    {
        //Snip...
        IntPtr drawTextExAPtr = EasyHook.LocalHook.GetProcAddress("user32", "DrawTextExA");
        _drawTextExAHook = EasyHook.LocalHook.Create(drawTextExAPtr, new DrawTextExDelegate(DrawTextEx_Hooked), null);
        //The COM stuff must be run in a STA Thread so we can intercept the message boxes that it throws up.
        var staThread = new Thread(() =>
            {
                try
                {
                    var threadID = new[] { GetCurrentThreadId() };
                    //Enable the hook on the current thread.
                    _drawTextExAHook.ThreadACL.SetInclusiveACL(threadID);
                    //Tell the dummy form to start ComThread
                    _dummyForm = new DummyForm(ComThread);
                    Application.Run(_dummyForm);
                }
                finally
                {
                    if(_drawTextExAHook != null)
                        _drawTextExAHook.Dispose();
                }
            });
        staThread.SetApartmentState(ApartmentState.STA);
        staThread.Name = "Com Thread";
        staThread.Start();
        //Wait for the Com Thread to finish.
        staThread.Join();
    }
    //Snip...
    private delegate int DrawTextExDelegate(IntPtr hdc, string lpchText, int cchText,
                    ref Rect lprc, uint dwDTFormat, ref DRAWTEXTPARAMS lpDTParams);
    private int DrawTextEx_Hooked(IntPtr hdc, string lpchText, int cchText, ref Rect lprc, 
                                         uint dwDTFormat, ref DRAWTEXTPARAMS lpDTParams)
    {
        LogErrorText(lpchText);
        return DrawTextEx(hdc, lpchText, cchText, ref lprc, dwDTFormat, ref lpDTParams);
    }
    [DllImport("user32.dll")]
    static extern int DrawTextEx(IntPtr hdc, string lpchText, int cchText,
                                 ref Rect lprc, uint dwDTFormat, ref DRAWTEXTPARAMS lpDTParams);
