    public partial class Form3 : Form
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    
            public Form3()
            {
                InitializeComponent();
                timer.Interval = 50;
                timer.Tick += timer_Tick;
            }
    
            void timer_Tick(object sender, EventArgs e)
            {
                timer.Stop();
                MessageBox.Show(richTextBox1.SelectedText);
    
                // do more stuff here, e.g display your tooltip for the selected word or anything else 
    
                richTextBox1.SelectionLength = 0; // remove the highlighted color of selection
            }
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    
            private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
            private const uint MOUSEEVENTF_LEFTUP = 0x04;
            private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
            private const uint MOUSEEVENTF_RIGHTUP = 0x10;
    
            public void DoMouseDoubleClick()
            {
                //Call the imported function with the cursor's current position
                uint X = (uint)Cursor.Position.X;
                uint Y = (uint)Cursor.Position.Y;
    
                mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
    
                timer.Start(); // some delay is required so that mouse event reach to RichTextBox and the word get selected
            }
    
            private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Middle)
                {
                    DoMouseDoubleClick();
                }
            }
        }
