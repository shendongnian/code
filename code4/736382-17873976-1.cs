    namespace q6359774
    {
        class MyRichTextBox : RichTextBox
        {
            const int EM_SETWORDBREAKPROC = 0x00D0;
            const int EM_GETWORDBREAKPROC = 0x00D1;
    
    
            delegate int EditWordBreakProc(string lpch, int ichCurrent, int cch, int code);
    
    	EditWordBreakProc oldEditWordBreakProc;	
    
            protected override void OnHandleCreated(EventArgs e)
            {
                base.OnHandleCreated(e);
                this.Text = "abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz";
                if (!this.DesignMode)
    	    {
                    IntPtr oldproc;
                    oldproc = SendMessage(this.Handle, EM_SETWORDBREAKPROC, IntPtr.Zero, Marshal.GetFunctionPointerForDelegate(new EditWordBreakProc(MyEditWordBreakProc)));
                    oldEditWordBreakProc = Marshal.GetDelegateForFunctionPointer(oldproc, typeof(EditWordBreakProc));
                }
            }
    
            [DllImport("User32.DLL")]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    
    
            int MyEditWordBreakProc(string lpch, int ichCurrent, int cch, int code)
            {
                const int WB_ISDELIMITER = 2;
                const int WB_CLASSIFY = 3;
                if (code == WB_ISDELIMITER)
                {
                    if (lpch.Length == 0 || lpch == null) return 0;
                    char ch = lpch[ichCurrent];
                    if (ch == '_')
    		{
                         return 0;
                    }
                    else return oldEditWordBreakProc(lpch, ichCurrent, cch, code);
                }
                else if (code == WB_CLASSIFY)
                {
                    if (lpch.Length == 0 || lpch == null) return 0;
                    char ch = lpch[ichCurrent];
                    var vResult = Char.GetUnicodeCategory(ch);
                    return (int)vResult;
                }
                else return oldEditWordBreakProc(lpch, ichCurrent, cch, code);
            }
        }
    }
