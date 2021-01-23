    public partial class MyWindow : Form, IMessageFilter
    {
        public MyWindow()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
        }
        public bool PreFilterMessage(ref Message m)
        {
            // WM_KEYDOWN
            if (m.Msg == 0x0100)
            {
                // Extract the keys being pressed
                Keys keys = ((Keys)((int)m.WParam.ToInt64()));
                // Test for the A key....
                if (keys == Keys.A)
                {
                    return true; // Prevent message reaching destination
                }
            }
        }
        return false;
    }
