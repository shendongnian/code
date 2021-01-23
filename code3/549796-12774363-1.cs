    public partial class frmNew : Form
    {
        public frmNew ()
        {
            InitializeComponent ();
        }
        private void btnCancel_Click ( object sender, EventArgs e )
        {
            // Is there an active instance of frmAdd? If yes,
            // call SetPicture() with a copy of the image used by
            // this frmNew.
            frmAdd oFrm = frmAdd.Instance;
            
            if ( oFrm != null )
                oFrm.SetPicture ( picNew.Image.Clone () as Image );
        }
    }
