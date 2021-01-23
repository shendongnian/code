        public partial class fmMain : Form
        { 
        
            private void btnrunBackgroundWorker_Click( object sender, EventArgs e )
            {
                // Create a background thread
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += new DoWorkEventHandler( bw_DoWork );
                     
                // run in another thread
                bw.RunWorkerAsync();     
            }
        
            private void bw_DoWork( object sender, DoWorkEventArgs e )
            {
               String googleHtml = simpleRequest("https://facebook.com");
            }
        }
