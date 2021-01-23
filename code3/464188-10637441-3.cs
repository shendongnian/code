        private static Process myProcess = null;
        public void OpenPDF()
        {
            myProcess = new Process();
            myProcess.StartInfo.FileName = "AcroRd32.exe";
            myProcess.StartInfo.Arguments = " /n /A \"pagemode=bookmarks&nameddest=" + strND + "\" \"" + strPath + "\"";
            myProcess.Start();
        }
        public void ClosePDF()
        {
            // If there is 
            if (myProcess!= null)
            {
                myProcess.CloseMainWindow();
                Thread.Sleep(500);
            }
        }
