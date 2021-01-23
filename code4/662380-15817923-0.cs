        private AutoResetEvent _fileUploadedEvent = new AutoResetEvent(false);
        private void DoUploadBackgroundWorker()
        {
            foreach (var file in files)
            {
                client.WhenUploaded += (s, e) =>
                    {
                        // This signals the AutoResetEvent that it can continue
                        _fileUploadedEvent.Set();
                    };
                client.UploadAsync();
                // This will keep ticking over every 15 milliseconds to check if the
                // AutoResetEvent has been triggered
                while (_fileUploadedEvent.WaitOne(15)) { }
                // We get here when it's been triggered (which means the file was uploaded)
                // So we can update the progressbar here and then move onto the next file.
            }
        }
