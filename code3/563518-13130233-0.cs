            delegate Image getImageDelegate(string url);
            private void Form1_Load(object sender, EventArgs e)
            {
                _getImage = new getImage();
    Image splashLogo = (Image)this.Invoke(new getImageDelegate(_getImage.fromURL), new object[] { "http://ace-acid.no-ip.org/GameClient/splash.png" });
                this.BackgroundImage = splashLogo;
                this.Show();
                
            }
 
