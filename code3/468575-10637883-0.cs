    public class MyTextBox : TextBox
    {
        private const int WM_CUT   = 0x0300;
        private const int WM_COPY  = 0x0301;
        private const int WM_PASTE = 0x0302;
		protected override void WndProc(ref Message m)
		{
            switch(m.Msg)
            {
                case WM_CUT:
                    // Handle Cut
                    return;
                case WM_COPY:  
                    // handle copy 
                    return;
                case WM_PASTE:
                    // handle paste
                    return;
            }
			base.WndProc(ref m);
		}
    }
