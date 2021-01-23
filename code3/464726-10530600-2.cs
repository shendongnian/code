    public partial class YourForm : Form, IMessageFilter
    {
        // Your code.
        public bool PreFilterMessage ( ref Message m )
        {
            if ( m.Msg == 0x20A )
            {
                NativeMethods.SendMessage ( controlToScroll.Handle , m.Msg , m.WParam , m.LParam );
                return true;
            }
            return false;
        }
    }
