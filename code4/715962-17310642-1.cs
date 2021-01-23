    public partial class Form1 : Form
    {
        [DllImport("user32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);        
        public Form1()
        {
            InitializeComponent();            
        }
        ChildUI child = new ChildUI();
        bool progressShown;
        IntPtr childHandle;
        //I suppose clicking on the button1 on the main ui form will show a progress form.
        private void button1_Click(object sender, EventArgs e)
        {
            if(!progressShown)
               new Thread(() => { progressShown = true; childHandle = child.Handle; child.ShowDialog(); progressShown = false; }).Start();
        }
        protected override void WndProc(ref Message m)
        {
            if (progressShown&&(m.Msg == 0x84||m.Msg == 0xA1||m.Msg == 0xA4||m.Msg == 0xA3||m.Msg == 0x6))  
            //0x84:  WM_NCHITTEST
            //0xA1:  WM_NCLBUTTONDOWN
            //0xA4:  WM_NCRBUTTONDOWN 
            //0xA3   WM_NCLBUTTONDBLCLK   //suppress maximizing ...
            //0x6:   WM_ACTIVATE         //suppress focusing by tab...
            {
                SetForegroundWindow(childHandle);//Bring your progress form to the front
                return;//filter out the messages
            }
            base.WndProc(ref m);
        }
    }
