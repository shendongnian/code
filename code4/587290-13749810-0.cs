    public sealed partial class MouseAlertForm : Form
    {
        private Image Logo;
        public Point MouseLocation { get; private set; }
        public MouseAlertForm(Point location)
        {
            InitializeComponent();
            MouseLocation = location; 
            // Allow transparent backgrounds.
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            // Set up this form to be maximum size, with no borders, and have a nearly transparent background.
            this.TopMost = true;
            this.DoubleBuffered = true;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Lime;
            this.TransparencyKey = Color.Lime;
            // Load the Image.
            var assembly = Assembly.GetAssembly(new AssemblyTypeLinker().GetType());
            if (assembly != null)
                Logo = Image.FromStream(assembly.GetManifestResourceStream("MyProgram.MyLogo.png"));
        }
        /// <summary>
        /// Update the current mouse location, and invalidate the control causing a re-draw.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            MouseLocation = e.Location;
            Invalidate();
        }
        /// <summary>
        /// Release our logo, and close the form.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            
            Logo.Dispose();
            this.Close();
        }
        /// <summary>
        /// Clear what was previously drawn, and if we have a mouse location, draw the logo in that area.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (MouseLocation != Point.Empty)
            {
                // Draw our logo in the spot of the current mouse location.
                e.Graphics.DrawImage(Logo, MouseLocation.X - 100, MouseLocation.Y - 100, 200, 200);
            }
        }
