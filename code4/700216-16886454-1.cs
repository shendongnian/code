            DefaultSystemBrowser.Determine();
            if ( DefaultSystemBrowser.ErrorMessage == null )
            {
                btnOpenInBrowser.Image = DefaultSystemBrowser.Bitmap;
            }
            else
            {
                btnOpenInBrowser.Image = Properties.Resources.firefox_24_noshadow;
            }
