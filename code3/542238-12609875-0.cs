    ////It appears that DrawText always calls DrawTextEx so it is getting intercepted twice.
    //// Only need to hook DrawTextEx
    //static EasyHook.LocalHook _drawTextAHook;
    //static EasyHook.LocalHook _drawTextWHook;
    static EasyHook.LocalHook _drawTextExAHook;
    
    //Snip...
    public override void Run()
    {
        //Snip...
        //IntPtr drawTextAPtr = EasyHook.LocalHook.GetProcAddress("user32", "DrawTextA");
        //_drawTextAHook = EasyHook.LocalHook.Create(drawTextAPtr, new DrawTextDelegate(DrawText_Hooked), new DrawTextDelegate(DrawTextA));
        //IntPtr drawTextWPtr = EasyHook.LocalHook.GetProcAddress("user32", "DrawTextW");
        //_drawTextWHook = EasyHook.LocalHook.Create(drawTextWPtr, new DrawTextDelegate(DrawText_Hooked), new DrawTextDelegate(DrawTextW));
        IntPtr drawTextExAPtr = EasyHook.LocalHook.GetProcAddress("user32", "DrawTextExA");
        _drawTextExAHook = EasyHook.LocalHook.Create(drawTextExAPtr, new DrawTextExDelegate(DrawTextEx_Hooked), null);
        //The COM stuff must be run in a STA Thread so we can intercept the message boxes that it throws up.
        var staThread = new Thread(() =>
            {
                try
                {
                    var threadID = new[] { GetCurrentThreadId() };
                    //Enable the hook on the current thread.
                    //_drawTextAHook.ThreadACL.SetInclusiveACL(threadID);
                    //_drawTextWHook.ThreadACL.SetInclusiveACL(threadID);
                    _drawTextExAHook.ThreadACL.SetInclusiveACL(threadID);
                    //Tell the dummy form to start ComThread
                    _dummyForm = new DummyForm(ComThread);
                    Application.Run(_dummyForm);
                }
                finally
                {
                    //if(_drawTextAHook != null)
                    //    _drawTextAHook.Dispose();
                    //if(_drawTextWHook != null)
                    //    _drawTextWHook.Dispose();
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
    //private delegate int DrawTextDelegate(IntPtr hDC, string lpchText, int nCount, ref Rect lpRect,
    //                              uint uFormat);
    private int DrawTextEx_Hooked(IntPtr hdc, string lpchText, int cchText, ref Rect lprc, 
                                         uint dwDTFormat, ref DRAWTEXTPARAMS lpDTParams)
    {
        LogErrorText(lpchText);
        return DrawTextEx(hdc, lpchText, cchText, ref lprc, dwDTFormat, ref lpDTParams);
    }
    //private int DrawText_Hooked(IntPtr hDC, string lpString, int nCount, ref Rect lpRect, uint uFormat)
    //{
    //    LogErrorText(lpString);
    //    var DrawText = (DrawTextDelegate)EasyHook.HookRuntimeInfo.Callback;
    //    return DrawText(hDC, lpString, nCount, ref lpRect, uFormat);
    //}
    [DllImport("user32.dll")]
    static extern int DrawTextEx(IntPtr hdc, string lpchText, int cchText,
                                 ref Rect lprc, uint dwDTFormat, ref DRAWTEXTPARAMS lpDTParams);
    //[DllImport("user32.dll")]
    //static extern int DrawTextA(IntPtr hDC, string lpString, int nCount, ref Rect lpRect,
    //                           uint uFormat);
    [DllImport("user32.dll")]
    static extern int DrawTextW(IntPtr hDC, string lpString, int nCount, ref Rect lpRect,
                               uint uFormat);
