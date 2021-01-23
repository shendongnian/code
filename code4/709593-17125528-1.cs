            IntPtr ID; 
            int counter = 0;//index to move window
    
            public Form1()
            {
                InitializeComponent();
                ID = this.Handle; //get handle of form    
            }
    
            [DllImport("user32.dll", SetLastError = true)]
            internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    
            //place a timer and in his tick event...
            //and choose the interval of the tick.
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                if (counter <= Screen.PrimaryScreen.Bounds.Right)
                    MoveWindow(ID, counter++, 0, this.Width, this.Height, true);
                else
                    counter = 0;
            }
