    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApplication3
    {
        public partial class InactiveForm : UserControl
        {
            private const int WS_EX_TOOLWINDOW = 0x00000080;
            private const int WS_EX_NOACTIVATE = 0x08000000;
            private const int WS_EX_TOPMOST = 0x00000008;
    
    
            [DllImport("user32")]
            public static extern int SetParent
             (IntPtr hWndChild, IntPtr hWndNewParent);
    
            [DllImport("user32")]
            public static extern int ShowWindow
             (IntPtr hWnd, int nCmdShow);
    
    
            protected override CreateParams CreateParams
            {
                get
                {
    
                    CreateParams p = base.CreateParams;
                    p.ExStyle |= (WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
                    p.Parent = IntPtr.Zero;
                    return p;
                }
            }
    
            public InactiveForm()
            {
                InitializeComponent();
            }
    
            public new void Show()
            {
                if (this.Handle == IntPtr.Zero) base.CreateControl();
    
                SetParent(base.Handle, IntPtr.Zero);
                ShowWindow(base.Handle, 1);
            }
    
    
            private void OnListBoxClicked(object sender, EventArgs e)
            {
                MessageBox.Show("Clicked List Box on floating control");
    
            }
        }
    }
 
