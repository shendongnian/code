    static void FunkyCopy2(string srcFname, string midFname, string dstFname)
    {
        var cancel = new CancellationTokenSource();
        const int bufferSize = 65536;
        var finfo = new FileInfo(srcFname);
        Console.WriteLine("File length = {0:N0} bytes", finfo.Length);
        long bytesCopiedToMid = 0;
        AutoResetEvent bytesAvailable = new AutoResetEvent(false);
        // First thread copies from src to mid
        var midThread = new Thread(() =>
            {
                Console.WriteLine("midThread started");
                using (
                    FileStream srcFile = new FileStream(srcFname, FileMode.Open, FileAccess.Read, FileShare.None),
                                midFile = new FileStream(midFname, FileMode.Create, FileAccess.Read,
                                                        FileShare.ReadWrite))
                {
                    var buffer = new byte[bufferSize];
                    while (bytesCopiedToMid < finfo.Length)
                    {
                        var srcBytesRead = srcFile.Read(buffer, 0, buffer.Length);
                        if (srcBytesRead > 0)
                        {
                            midFile.Write(buffer, 0, srcBytesRead);
                            Interlocked.Add(ref bytesCopiedToMid, srcBytesRead);
                            bytesAvailable.Set();
                        }
                    }
                }
                Console.WriteLine("midThread exit");
            });
        // Second thread copies from mid to dst
        var dstThread = new Thread(() =>
            {
                Console.WriteLine("dstThread started");
                using (
                    FileStream midFile = new FileStream(midFname, FileMode.Open, FileAccess.Read,
                                                        FileShare.ReadWrite),
                                dstFile = new FileStream(dstFname, FileMode.Create, FileAccess.Write, FileShare.Write)
                    )
                {
                    long bytesCopiedToDst = 0;
                    var buffer = new byte[bufferSize];
                    while (bytesCopiedToDst != finfo.Length)
                    {
                        // if we've already copied everything from mid, then wait for more.
                        if (Interlocked.CompareExchange(ref bytesCopiedToMid, bytesCopiedToDst, bytesCopiedToDst) ==
                            bytesCopiedToDst)
                        {
                            bytesAvailable.WaitOne();
                        }
                        var midBytesRead = midFile.Read(buffer, 0, buffer.Length);
                        if (midBytesRead > 0)
                        {
                            dstFile.Write(buffer, 0, midBytesRead);
                            bytesCopiedToDst += midBytesRead;
                            Console.WriteLine("{0:N0} bytes copied to destination", bytesCopiedToDst);
                        }
                    }
                }
                Console.WriteLine("dstThread exit");
            });
        midThread.Start();
        dstThread.Start();
        midThread.Join();
        dstThread.Join();
        Console.WriteLine("Done!");
    }
