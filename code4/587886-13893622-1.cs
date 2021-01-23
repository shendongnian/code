        void webBrowserFB_Navigated(object sender, System.Windows.Forms.WebBrowserNavigatedEventArgs e)
        {
            try
            {
                if (webBrowserFB.Url.OriginalString.StartsWith("https://www.facebook.com/connect/login_success.html"))
                {
                    redirect_url = webBrowserFB.Url.OriginalString;                    
                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
