        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(1); //to invoke ProgressChanged
            t3 = runComparison(); //run intensive method
            e.Result = t3; //return DataTable
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Visible = true; //display a label
            textBoxProgress.Visible = true; //display the progress bar
            //change the progress bar style
            //the Marquee style is constantly running, so it could show users the process is working
            //not too sure how to explain it, you'll have to try it out. 
            progressBar1.Style = ProgressBarStyle.Marquee; 
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("An unexpected error has occurred. Please try again later.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //reset the display and update the DataGridView
                progressBar1.Visible = false;
                textBoxProgress.Visible = false;
                progressBar1.Style = ProgressBarStyle.Blocks;
                dataGridView1.DataSource = e.Result;
            }
        }
