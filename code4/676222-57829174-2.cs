        public static void ParallelExtract(
            string archivePath,
            string destinationPath,
            string password,
            CancellationToken token,
            ProgressReportDelegate progress // Could also be Progress<T> or whatever you prefer.
            )
        {
            if (String.IsNullOrEmpty(archivePath))
                throw new ArgumentNullException("archivePath");
            if (String.IsNullOrEmpty(destinationPath))
                throw new ArgumentNullException("destinationPath");
            Stopwatch elapsed = new Stopwatch();
            Stopwatch progressReportingTimer = new Stopwatch();
            elapsed.Start();
            progressReportingTimer.Start();
            object obj = new object();
            int count = -1;
            long bytesExtracted = 0;
            long bytesTotal = -1;
            List<Task> decompressors = new List<Task>();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                decompressors.Add(Task.Run(() =>
                {
                    using (ZipFile zipFile = new ZipFile(archivePath))
                    {
                        if (!String.IsNullOrEmpty(password))
                            zipFile.Password = password;
                        zipFile.ExtractProgress += delegate (object zipSender, ExtractProgressEventArgs zipArgs)
                        {
                            // Report progress after each EntryBytesWritten event, as long as it's been at least 250ms since the last report, so as to not
