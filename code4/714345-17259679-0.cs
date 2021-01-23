    **EDIT**
    class YourClass
        {
            string filePath;
            DataSet dataset;
            private static void Do_Work(object sender, DoWorkEventArgs e)
            {
                //populate dataset
                //call worker.ReportProgress to trigger worker.ProgressChanged 
                //rest of time consuming ADO.Net Codes and other codes you wrote in your DoWork method
            }
    
            private static void Progress_Changed(object sender, ProgressChangedEventArgs e)
            {
                //this method is invoked in the thread where background worker is instantiated.
                //do all UI stuff here like populating datagridview from dataset
            }
        }
