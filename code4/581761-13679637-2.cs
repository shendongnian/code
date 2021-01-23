        public static void ParallelDownloadFile(string uri, string filePath, int chunkSize)
        {
            if (uri == null)
                throw new ArgumentNullException("uri");
            // determine file size first
            long size = GetFileSize(uri);
            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                file.SetLength(size); // set the length first
                object syncObject = new object(); // synchronize file writes
                Parallel.ForEach(LongRange(0, 1 + size / chunkSize), (start) =>
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                    request.AddRange(start * chunkSize, start * chunkSize + chunkSize - 1);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    lock (syncObject)
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            file.Seek(start * chunkSize, SeekOrigin.Begin);
                            stream.CopyTo(file);
                        }
                    }
                });
            }
        }
        public static long GetFileSize(string uri)
        {
            if (uri == null)
                throw new ArgumentNullException("uri");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "HEAD";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response.ContentLength;
        }
        private static IEnumerable<long> LongRange(long start, long count)
        {
            long i = 0;
            while (true)
            {
                if (i >= count)
                {
                    yield break;
                }
                yield return start + i;
                i++;
            }
        }
