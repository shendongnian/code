    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void mouse_down(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            UnsafeNativeMethods2.ReleaseCapture(ctrl.Handle);
            this.Drag(); // put the form into drag mode.
        }
        public void Drag()
        {
            UnsafeNativeMethods2.DefWindowProc(this.Handle, UnsafeNativeMethods2.WM_SYSCOMMAND, (IntPtr) UnsafeNativeMethods2.MOUSE_MOVE, IntPtr.Zero);
        }
    }
