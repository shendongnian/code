    public class AsyncFileUpdate
    {
        object locker = new object();
        public FileInfo File { get; private set; }
        public AsyncFileUpdate(FileInfo file)
        {
            File = file;
        }
        /// <summary>
        /// Reads contents of a file asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task<string> ReadFileAsync()
        {
            return Task.Factory.StartNew<string>(() =>
                {
                    lock (locker)
                    {
                        using (var fs = File.OpenRead())
                        {
                            StreamReader reader = new StreamReader(fs);
                            using (reader)
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                });
        }
        /// <summary>
        /// write file asynchronously
        /// </summary>
        /// <param name="content">string to write</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task WriteFileAsync(string content)
        {
            return Task.Factory.StartNew(() =>
            {
                lock (locker)
                {
                    using (var fs = File.OpenWrite())
                    {
                        StreamWriter writer = new StreamWriter(fs);
                        using (writer)
                        {
                            writer.Write(content);
                            writer.Flush();
                        }
                    }
                }
            });
        }
    }
    /// <summary>
    /// Demonstrates usage
    /// </summary>
    public class FileOperations
    {
        public void ProcessAndUpdateFile(FileInfo file)
        {
            AsyncFileUpdate fu = new AsyncFileUpdate(file); ;
            fu.ReadFileAsync()
                .ContinueWith(p => Process(p.Result))
                .ContinueWith(p => fu.WriteFileAsync(p.Result));
        }
        /// <summary>
        /// does the processing on the file content
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        string Process(string content)
        {
            throw new NotImplementedException("you do this bit ;)");
        }
    }
