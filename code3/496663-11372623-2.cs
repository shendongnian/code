    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    namespace ConsoleApplication36
    {
        class Program
        {
            private const string FileName = @"C:\Users\Public\movies.list";
            private const long ThreadReadBlockSize = 50000;
            private const int NumberOfThreads = 4;
            private static byte[] _inputString;
            static void Main(string[] args)
            {
                var fi = new FileInfo(FileName);
                long totalBytesRead = 0;
                long fileLength = fi.Length;
                long readPosition = 0L;
                Console.WriteLine("Reading Lines From {0}", FileName);
                var threads = new Thread[NumberOfThreads];
                var instances = new ReadThread[NumberOfThreads];
                _inputString = new byte[fileLength];
                while (totalBytesRead < fileLength)
                {
                    for (int i = 0; i < NumberOfThreads; i++)
                    {
                        var rt = new ReadThread { StartPosition = readPosition, BlockSize = ThreadReadBlockSize };
                        instances[i] = rt;
                        threads[i] = new Thread(rt.Read);
                        threads[i].Start();
                        readPosition += ThreadReadBlockSize;
                    }
                    for (int i = 0; i < NumberOfThreads; i++)
                    {
                        threads[i].Join();
                    }
                    for (int i = 0; i < NumberOfThreads; i++)
                    {
                        if (instances[i].BlockSize > 0)
                        {
                            Array.Copy(instances[i].Output, 0L, _inputString, instances[i].StartPosition,
                                       instances[i].BlockSize);
                            totalBytesRead += instances[i].BlockSize;
                        }
                    }
                }
                string finalString = Encoding.ASCII.GetString(_inputString);
                Console.WriteLine(finalString.Substring(104250000, 50000));
            }
            private class ReadThread
            {
                public long StartPosition { get; set; }
                public long BlockSize { get; set; }
                public byte[] Output { get; private set; }
                public void Read()
                {
                    Output = new byte[BlockSize];
                    var inStream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    inStream.Seek(StartPosition, SeekOrigin.Begin);
                    BlockSize = inStream.Read(Output, 0, (int)BlockSize);
                    inStream.Close();
                }
            }
        }
    }
