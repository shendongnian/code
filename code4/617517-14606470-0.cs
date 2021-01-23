    public partial class frmQuizMaster : Form, IMessageFilter {
        clsGetInputID MouseHandler;
    //  Initialization
        public frmQuizMaster() {
            InitializeComponent();
            Application.AddMessageFilter(this);
        }
        private void frmQuizMaster_Load(object sender, EventArgs e) {
            MouseHandler = new clsGetInputID(this.Handle);
        }
        private void frmQuizMaster_FormClosing(object sender, FormClosingEventArgs e) {
            Application.RemoveMessageFilter(this);
        }
        public bool PreFilterMessage(ref Message message) {
            int HardID = MouseHandler.GetDeviceID(message);
            if (HardID > 0) {
                System.Diagnostics.Debug.WriteLine("Device ID : " + HardID.ToString());
                //Return true here if you want to supress the mouse click
                //bear in mind that mouse down and up messages will still pass through, so you will need to filter these out and return true also.
            }
            return false;
        }
