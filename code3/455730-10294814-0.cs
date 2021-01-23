    using System.Net;
    using System.IO;
            private void Form1_Load(object sender, EventArgs e)
            {
                WebClient webclient = new WebClient();
                webclient.DownloadDataAsync(new Uri("http://mySite/logo.gif"));
                webclient.DownloadDataCompleted += callback;
    
            }
            void callback(object sender,DownloadDataCompletedEventArgs e)
            {
                var ms = new MemoryStream(e.Result);
                pictureBox1.Image = Image.FromStream(ms);
            }
