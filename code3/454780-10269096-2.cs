    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.private void MMForm(object sender, KeyPressEventArgs e)
        }
        private void MMForm(object sender, KeyPressEventArgs e)
         {
            if (e.KeyChar == Convert.ToChar(((int)Keys.Escape)))
            {
                frm2 fM2 = new frm2(); fm2.Height=200; fm2.Width=200; fM2.Show(); 
            }
    }
    public class frm2 : Form 
    { 
        public frm2() 
        {  
            InitializeComponent();
        } 
    } 
