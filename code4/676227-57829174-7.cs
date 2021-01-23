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
                            // Report progress after each EntryBytesWritten event, as long as it's been at least 250ms since the last report, so as to not overwhelm listeners like a progress bar. 
                            // Fire regardless upon completion (bytesExtracted == bytesTotal) to provide a final update before finishing.
                            if ((zipArgs.EventType == ZipProgressEventType.Extracting_EntryBytesWritten && progressReportingTimer.ElapsedMilliseconds >= 250) || bytesExtracted == bytesTotal)
                            {
                                int percentage = Percentage(bytesExtracted, bytesTotal);
                                lock (obj)
                                {
                                    progress?.Invoke(); // <-- Handle your progress updates here.
                                    progressReportingTimer.Restart();
                                }
                            }
                        };
                        // Block all threads until we sum the total size of all entries so that when we begin processing on the threadpool we 
                        // can report progress relative to the total.
                        lock (obj)
                            if (bytesTotal == -1)
                                foreach (var entry in zipFile.Entries)
                                    bytesTotal += entry.CompressedSize;
                        var array = zipFile.Entries.ToArray();
                        int index;
                        ZipEntry zipEntry;
                        // Iterate through the archive's entries sequentially despite being on multiple threads.
                        while (count < zipFile.Entries.Count && !token.IsCancellationRequested)
                        {
                            index = Interlocked.Increment(ref count);
                            if (index >= zipFile.Entries.Count)
                                return;
                            zipEntry = array[index];
                            Interlocked.Add(ref bytesExtracted, zipEntry.CompressedSize);
                            zipEntry.Extract(destinationPath, ExtractExistingFileAction.OverwriteSilently);
                        }
                    }
                },
                token
                ));
            }
            Task.WaitAll(decompressors.ToArray());
        }
