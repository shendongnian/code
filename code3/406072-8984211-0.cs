        private const int WM_SYSCOMMAND = 0x0112; 
        private const int SC_MINIMIZE = 0xf020;
        protected override void WndProc(ref Message m) 
        { 
            if (m.Msg == WM_SYSCOMMAND) 
            { 
                if (m.WParam.ToInt32() == SC_MINIMIZE) 
                { 
                    m.Result = IntPtr.Zero; 
                    panel1.Height = this.Height; // cover the whole form
                    panel1.Width = this.Width;
                    panel1.Visible = true; // make it visible
                }
            } 
            base.WndProc(ref m); 
        } 
