    1. In the constructor store the childForm and ParentForm object in a local variables. 
    	   And Set the The properties (like width,height) to the Overlay Window
    	2. In the OverlayForm_Load show the ChildForm window.
	
    public partial class OverlayForm : Form
    {
        public Form ParentForm { get; set; }
        public Form child { get; set; }
        public OverlayForm(Form parent, Form child)
        {
            InitializeComponent();
            this.child = child;
            this.ParentForm = parent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.Width = ParentForm.Width;
            this.Height = ParentForm.Height;
            this.Top = ParentForm.Top;
            this.Left = ParentForm.Left;
            this.StartPosition = ParentForm.StartPosition;
            // Set the opacity to 75%.
            this.Opacity = .75;
        }
        private void OverlayForm_Load(object sender, EventArgs e)
        {
            child.Show();
            child.TopMost = true;
            child.Focus();
            child.BringToFront();
        }
    }
	
