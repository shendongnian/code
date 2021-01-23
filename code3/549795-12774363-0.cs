    public partial class frmAdd : Form
    {
        // Stores a reference to the currently shown frmAdd instance.
        private static frmAdd s_oInstance = null;
        
        // Returns the reference to the currently shown frmAdd instance
        // or null if frmAdd is not shown. Static, so other forms can
        // access this, even when an instance is not available.
        public static frmAdd Instance
        {
            get
            {
                return ( s_oInstance );
            }
        }
        
        public frmAdd ()
        {
            InitializeComponent ();
        }
        
        // Sets the specified picture. This is necessary because picAdd
        // is private and it's not a good idea to make it public.
        public void SetPicture ( Image oImage )
        {
            picAdd.Image = oImage;
        }
        // These event handlers are used to track if an frmAdd instance
        // is available. If yes, they update the private static reference
        // so that the instance is available to other forms.
        private void frmAdd_Load ( object sender, EventArgs e )
        {
            // Form is loaded (not necessarily visible).
            s_oInstance = this;
        }
        private void frmAdd_FormClosed ( object sender, FormClosedEventArgs e )
        {
            // Form has been closed.
            s_oInstance = null;
        }
        // Whatever other code you need
    }
