    public class YourForm : Form
    {
        private bool bIsClosing = false;
        Private bool bClosingHandled = false;
    
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
                bClosingHandled = true;
                this.close(); 
            }
            else
            {
                // Do someting different
            }
        }
    
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            If(!bClosingHandled)
            {
              bIsClosing = true;
              e.Cancel = true;
              return;
            }
            
            // Write the Logfile
            doLog("whatever");
        }
    }`
