    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.TopMost = true; // make the form always on top
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // hidden border
            this.WindowState = FormWindowState.Maximized; // maximized
            this.MinimizeBox = this.MaximizeBox = false; // not allowed to be minimized
            this.MinimumSize = this.MaximumSize = this.Size; // not allowed to be resized
            this.TransparencyKey = this.BackColor = Color.Red; // the color key to transparent, choose a color that you don't use
            // Set the form click-through
            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
        }
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // draw what you want
            e.Graphics.FillEllipse(Brushes.Blue, 30, 30, 100, 100);
        }
    }
