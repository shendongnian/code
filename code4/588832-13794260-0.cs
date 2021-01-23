            public void WndProc(ref Microsoft.WindowsCE.Forms.Message m)
            {
                if (m.Msg == WM_KEYDOWN && (m.WParam == (IntPtr)VK_RETURN && m.LParam != (IntPtr)1))
                {
                     //Handle hard button
                }
            }
