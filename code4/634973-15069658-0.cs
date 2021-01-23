    public class YourForm : Form
    {
        private bool bIsClosing = false;
        public YourClass()
        {
           InitializeComponent();
           this.FormClosing +=
               new FormClosingEventHandler(MyForm_FormClosing);
        }
        private void txb_Validating(object sender, CancelEventArgs e)
        {
            doLog("Text 1");
        }
    
        private void dgv_CellValueChanged(object sender,
            DataGridViewCellEventArgs e)
        {
            doLog("Text 2");
        }
    
        private void doLog(string txt)
        {
            // this is first called at closing...
            if( bIsClosing )
            {
                // Do something
            }
            else
            {
                // Do someting different
            }
        }
    
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bIsClosing = true;
            // Write the Logfile
            doLog("whatever");
        }
    }
