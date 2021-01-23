        public async Task<int> Download(...)
        {
            bool downloadCompleted = false;
            var bd = AppDomain.CurrentDomain.BaseDirectory;
            var fn = bd + "/" + i + ".7z";
            var down = new WebClient();
            DownloadProgressChangedEventHandler dpc = (s, e) =>
            {
                label1.Text = "Download Update: " + i + " / " + ServID;
                int rec = Convert.ToInt16(e.BytesReceived / 1024);
                int total = Convert.ToInt16(e.TotalBytesToReceive / 1024);
                label2.Text = "Downloaded: " + rec.ToString() + "KB / " + total.ToString() + " KB";
                pb.Value = e.ProgressPercentage;
            };
            AsyncCompletedEventHandler dfc = null; dfc = (s, e) =>
            {
                label1.Text = "Extracting Files...";
                Rar Ra = new Rar();
                Ra.Open(i + ".7z");
                Ra.Unrar(AppDomain.CurrentDomain.BaseDirectory);
                File.Delete(fn);
                down.DownloadProgressChanged -= dpc;
                down.DownloadFileCompleted -= dfc;
                down.Dispose();
                if (ServID == i)
                {
                    button1.Enabled = true;
                    label1.Text = "Have Fun In-Game...";
                    label2.Text = "Done...";
                }
                downloadCompleted = true;
            };
            down.DownloadProgressChanged += dpc;
            down.DownloadFileCompleted += dfc;
            down.DownloadFileAsync(new Uri("http://unknowndekaron.net/updatee/" + i + "/" + i + ".7z"), fn);
            while (!downloadCompleted)
                ;
        }
