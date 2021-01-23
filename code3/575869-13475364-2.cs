            public static void ClearMouseClickQueue()
        {
            win32msg.NativeMessage message;
            while (win32msg.PeekMessage(out message, IntPtr.Zero, (uint)win32msg.WM.WM_MOUSEFIRST, (uint)win32msg.WM.WM_MOUSELAST, 1))
            {
            }
        }
        ...
                private void button1_Click_1(object sender, EventArgs e)
        {
            addLog("Button 1 clicked");
            button1.Enabled = false;
            button2.Enabled = false;
            panel1.Visible = false;
            System.Threading.Thread.Sleep(2000);
            ClearMouseClickQueue();
            panel2.Visible = true;
            button2.Enabled = true;
        }
