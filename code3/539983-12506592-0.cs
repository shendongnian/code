        Form1 msgForm;
        public void transmitprotocol()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            //you can use progresschange in order change waiting message while background working
            msgForm = new Form1();//set lable and your waiting text in this form
            try
            {
                bw.RunWorkerAsync();//this will run all Transmitting protocol coding at background thread
                //MessageBox.Show("Please wait. Uploading logo.", "Status");
                msgForm.ShowDialog();//use controlable form instead of poor MessageBox
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // Transmitting protocol coding here. Takes around 2 minutes to finish.   
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //all background work has complete and we are going to close the waiting message
            msgForm.Close();
        }
 
