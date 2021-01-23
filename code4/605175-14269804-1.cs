    Process[] collectionOfProcess = Process.GetProcessesByName("AcroRd32");
                if (collectionOfProcess.Length >= 1)
                {
                    Process acrProcess = collectionOfProcess[0];
                    
                    MessageBox.Show(acrProcess.MainWindowTitle);// file name of the which is opened.
    
                    MessageBox.Show("Acrobet reader running");
                }
