        private void ThreadForAnalyzingReqFile_DoWork(object sender, DoWorkEventArgs e)
        {
            AnotherClass processor = new AnotherClass();
            processor.ProgressUpdate += new AnotherClass.ReallyLongProcessProgressHandler(this.Processor_ProgressUpdate);
            processor.AVeryLongTimedFunction();
        }
        private void Processor_ProgressUpdate(double percentComplete)
        {
            
            this.progressBar1.Invoke(new Action(delegate()
            {
                this.progressBar1.Value = (int)(100d*percentComplete); // Do all the ui thread updates here
            }));
        }
