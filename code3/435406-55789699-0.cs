    using System;
    using System.Runtime.InteropServices;
    namespace IE_Automation
    {
    public class IEPoppupWindowClicker
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);
        private const int BM_CLICK = 0xF5;
        private const uint WM_ACTIVATE = 0x6;
        private const int WA_ACTIVE = 1;
        public void ActivateAndClickOkButton()
        {
            // find dialog window with titlebar text of "Message from webpage"
            var hwnd = FindWindow("#32770", "Message from webpage");
            if (hwnd != IntPtr.Zero)
            {
                // find button on dialog window: classname = "Button", text = "OK"
                var btn = FindWindowEx(hwnd, IntPtr.Zero, "Button", "OK");
                if (btn != IntPtr.Zero)
                {
                    // activate the button on dialog first or it may not acknowledge a click msg on first try
                    SendMessage(btn, WM_ACTIVATE, WA_ACTIVE, 0);
                    // send button a click message
                   
                    SendMessage(btn, BM_CLICK, 0, 0);
                }
                else
                {
                    //Interaction.MsgBox("button not found!");
                }
            }
            else
            {
                //Interaction.MsgBox("window not found!");
            }
        }
    }
    }
