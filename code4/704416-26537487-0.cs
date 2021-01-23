        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if ((int)e.CurrentProgress > 0)
            {
                ProgressBar.Maximum = (int)e.MaximumProgress;
                if (ProgressBar.Maximum == (int)e.MaximumProgress)
                    ProgressBar.Value = 0;
                ProgressBar.Value = (int)e.CurrentProgress;                
            }
        }
