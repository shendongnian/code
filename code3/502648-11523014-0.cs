    mWebClient.DownloadProgressChanged += (sender, e) => progressChanged(e.BytesReceived);
    //...
    DateTime lastUpdate;
    long lastBytes = 0;
        private void progressChanged(long bytes)
        {
            if (lastBytes == 0)
            {
                lastUpdate = DateTime.Now;
                lastBytes = bytes;
                return;
            }
            var now = DateTime.Now;
            var timeSpan = now - lastUpdate;
            var bytesChange = bytes - lastBytes;
            var bytesPerSecond = bytesChange / timeSpan.Seconds;
            lastBytes = bytes;
            lastUpdate = now;
        }
