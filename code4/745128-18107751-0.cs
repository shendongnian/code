    public class MyForm : Form
    {
        // other code
    
        protected override void WndProc(ref Message m)
        {
            const int WM_ACTIVATEAPP = 0x001C;
            switch (m.Msg)
            {
                case WM_ACTIVATEAPP:
                {
                    if (m.WParam)
                    {
                        // Your application's window is being activated, so
                        // do whatever it is you want. Or raise an event.
                        ...
                    }
                    break;
                }
                base.WndProc(ref m);  // proceed with default processing
            }
        }
    }
