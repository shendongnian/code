    public partial class Form1 : Form
    {
        private const uint WM_UPDATEUISTATE = 0x0128;
        private const uint WM_QUERYUISTATE = 0x0129;
        private const uint UIS_CLEAR = 2;
        private const uint UISF_HIDEACCEL = 0x2;
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (HideAccelIsSet())
                ClearHideAccel();
        }
        private bool HideAccelIsSet()
        {
            IntPtr res = NativeMethods.SendMessage(this.Handle, WM_QUERYUISTATE, UIntPtr.Zero, IntPtr.Zero);
            return (res.ToInt32() & UISF_HIDEACCEL) != 0;
        }
        private void ClearHideAccel()
        {
            UIntPtr wParam = (UIntPtr)((UISF_HIDEACCEL << 16) | UIS_CLEAR);
            NativeMethods.SendMessage(this.Handle, WM_UPDATEUISTATE, wParam, IntPtr.Zero);
        }
    }
    internal class NativeMethods
    {
        [DllImport("User32", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);
    }
