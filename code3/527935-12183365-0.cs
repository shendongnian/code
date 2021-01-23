     [DllImport("user32.dll", SetLastError = true)]
            static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
            public static void PressKey(Keys key, bool up)
            {
                const int KEYEVENTF_EXTENDEDKEY = 0x1;
                const int KEYEVENTF_KEYUP = 0x2;
                if (up)
                {
                    keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
                }
                else
                {
                    keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                webBrowser1.Navigate("http://google.com");//Your link
                webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted); 
            }
    
            void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                //Find your link and right click(automatically by your code)
                webBrowser1.Document.MouseDown += new HtmlElementEventHandler(Document_MouseDown);
            }
    
            void Document_MouseDown(object sender, HtmlElementEventArgs e)
            {
                if (e.MouseButtonsPressed == MouseButtons.Right)
                {
                    Thread.Sleep(1000);
                    PressKey(Keys.P, true);
                    PressKey(Keys.P, false);
                }
            }
