        /// <summary>
        /// Waits for completion of writing to a file.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <param name="timeToWait">The time to wait on each attempt.</param>
        /// <param name="retryAttempts">The maximum number of retry attempts.</param>
        /// <param name="safetyBuffer">The safety buffer.</param>
        public static void WaitForFile(string fullPath, TimeSpan timeToWait, int retryAttempts, TimeSpan safetyBuffer)
        {
            var timesSkipped = 0;
            var info = new FileInfo(fullPath);
            var maxWriteTime = DateTime.Now.Add(-safetyBuffer);// no activity for a minute
            while (info.Exists && (info.LastWriteTime > maxWriteTime) && timesSkipped < retryAttempts) {
                Thread.Sleep(timeToWait);
                maxWriteTime = DateTime.Now.Add(-safetyBuffer);
                info.Refresh();
                timesSkipped++;
            }
        }
