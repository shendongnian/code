    // Add IMessageFilter to the form
    public partial class Form1 : Form, IMessageFilter
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x09)
                {
                    return true;
                }
            return false;
        }
