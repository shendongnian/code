     FrmStatus FStatus = null;
    
            public void ProgressInit(String caption, string opis, int Max)
            {
                FStatus = new SZOKZZ.FrmStatus();
                FStatus.InitProc(Max);
                FStatus.SetCaption(caption, opis);
                FStatus.Show();
            }
    		
            public void DLProgress(string curl, string cdl)
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DLDone);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DLSetProc);
                webClient.DownloadFileAsync(new Uri(curl), cdl);
            }
            private void DLSetProc(object sender, DownloadProgressChangedEventArgs e)
            {
                this._FileProcentDownloaded = e.ProgressPercentage;
                FStatus.SetProcDL(this._FileProcentDownloaded);
    
            }
    		private void DLDone(object sender, AsyncCompletedEventArgs e)
            {
                _DlError = e.Error;
                FStatus.Dispose();
                FStatus = null;
            }
