        public partial class MyForm: Form, IMessageFilter
    ...
     public ImageForm(Image initialImage)
            {
                InitializeComponent();            
                Application.AddMessageFilter(this);
            }
    
    /// <summary>
            /// Filters out a message before it is dispatched.
            /// </summary>
            /// <returns>
            /// true to filter the message and stop it from being dispatched; false to allow the message to continue to the next filter or control.
            /// </returns>
            /// <param name="m">The message to be dispatched. You cannot modify this message. </param><filterpriority>1</filterpriority>
            public bool PreFilterMessage( ref Message m )
            {
                if (m.Msg.IsWindowMessage(WindowsMessages.MOUSEWHEEL))  //if (m.Msg == 0x20a)
                {   // WM_MOUSEWHEEL, find the control at screen position m.LParam      
                    var pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                    var hWnd = WindowFromPoint(pos);
                    if (hWnd != IntPtr.Zero && hWnd != m.HWnd && FromHandle(hWnd) != null)
                    {
                        SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
                        return true;
                    }
                }
    
                return false;
            }
    
            
            [DllImport("user32.dll")]
            private static extern IntPtr WindowFromPoint(Point pt);
    
            [DllImport("user32.dll")]
            private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
