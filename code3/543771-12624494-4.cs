    public partial class UserControl1 : UserControl
    {
        public UserControl1() {
            InitializeComponent();
            this.Load += UsersGrid_Load;
        }
    
        // Event fires when the MouseClick event fires for the UC or any of its child controls.
        public event EventHandler<EventArgs> WasClicked;
    
        private void UsersGrid_Load(object sender, EventArgs e) {
            // Register the MouseClick event with the UC's surface.
            this.MouseClick += Control_MouseClick;
            // Register MouseClick with all child controls.
            foreach (Control control in Controls) {
                control.MouseClick += Control_MouseClick;
            }
        }
    
        private void Control_MouseClick(object sender, MouseEventArgs e) {
            var wasClicked = WasClicked;
            if (wasClicked != null) {
                WasClicked(this, EventArgs.Empty);
            }
             // Select this UC on click.
             IsSelected = true;
        }
    
        private bool _isSelected;
        public bool IsSelected {
            get { return _isSelected; }
            set {
                _isSelected = value;
                this.BorderStyle = IsSelected ? BorderStyle.Fixed3D : BorderStyle.None;
            }
        }
    }
 
