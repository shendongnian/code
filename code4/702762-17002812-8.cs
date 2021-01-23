    public partial class Form1 : Form
    {
        // import necessary API functions to get and set Windows styles for P/Invoke
        [DllImport("user32.dll")]
        internal extern static int SetWindowLong(IntPtr hwnd, int index, int value);
    
        [DllImport("user32.dll")]
        internal extern static int GetWindowLong(IntPtr hwnd, int index);
    
        // define constants like they are named in SDK in order to make source more readable
        const int GWL_STYLE = -16;
        const int GWL_EXSTYLE = -20;
        const int WS_MINIMIZEBOX = 0x00020000;
        const int WS_MAXIMIZEBOX = 0x00010000;
        const int WS_CAPTION = 0x00C00000;
        const int WS_THICKFRAME = 0x00040000;
        const int WS_EX_DLGMODALFRAME = 0x00000001;
        const int WS_EX_CLIENTEDGE = 0x00000200;
        const int WS_EX_STATICEDGE = 0x00020000;
    
        // this replaces MinimizeBox=false and MaximizeBox=false
        void HideMinimizeAndMaximizeButtons()
        {
            // read current style
            int style = GetWindowLong(Handle, GWL_STYLE);
            Debug.WriteLine("0x{0:X}", style);
            // update style - remove flags for MinimizeBox and MaximizeBox
            style = style & ~WS_MINIMIZEBOX & ~WS_MAXIMIZEBOX;
            Debug.WriteLine("0x{0:X}", style);
            SetWindowLong(Handle, GWL_STYLE, style);
        }
    
        // part of removing the whole border
        void HideTitleBar()
        {
            // read current style
            int style = GetWindowLong(Handle, GWL_STYLE);
            Debug.WriteLine("0x{0:X}", style);
            // update style - remove flag for caption
            style = style & ~WS_CAPTION;
            Debug.WriteLine("0x{0:X}", style);
            SetWindowLong(Handle, GWL_STYLE, style);
        }
    
        // hide the border
        void HideBorder()
        {
            // read current style
            int style = GetWindowLong(Handle, GWL_STYLE);
            Debug.WriteLine("0x{0:X}", style);
            // update style - remove flag for border (could use WS_SIZEBOX which is the very same flag (see MSDN)
            style = style & ~WS_THICKFRAME;
            Debug.WriteLine("0x{0:X}", style);
            SetWindowLong(Handle, GWL_STYLE, style);
    
            // read current extended style
            style = GetWindowLong(Handle, GWL_EXSTYLE);
            Debug.WriteLine("0x{0:X}", style);
            // update style by removing some additional border styles -
            // may not be necessary, when current border style is not something exotic,
            // i.e. as long as it "normal"
            style = style & ~WS_EX_DLGMODALFRAME & ~WS_EX_CLIENTEDGE & ~WS_EX_STATICEDGE;
            Debug.WriteLine("0x{0:X}", style);
            SetWindowLong(Handle, GWL_EXSTYLE, style);
        }
    
        public Form1()
        {
            InitializeComponent();
    
            // hide those unwanted properties - you can try to leave out one or another to see what it does
            HideMinimizeAndMaximizeButtons();
            HideTitleBar();
            HideBorder();
        }
    }
