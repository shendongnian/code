    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void mouse_down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UnsafeNativeMethods.ReleaseCapture();
                UnsafeNativeMethods.SendMessage(Handle, UnsafeNativeMethods.WM_NCLBUTTONDOWN, UnsafeNativeMethods.HT_CAPTION, 0);
            }
        }
    }
