        private void RequestCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var feedXml = XDocument.Parse(e.Result);
                // (...)
            }
        }
