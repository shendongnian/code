    private static void FunkyCopy(string srcFname, string midFname, string dstFname)
    {
        using (FileStream srcFile = new FileStream(srcFname, FileMode.Open, FileAccess.Read, FileShare.None),
                            midFile = new FileStream(midFname, FileMode.Create, FileAccess.ReadWrite,
                                                    FileShare.ReadWrite),
                            dstFile = new FileStream(dstFname, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            long totalBytes = 0;
            var buffer = new byte[65536];
            while (totalBytes < srcFile.Length)
            {
                var srcBytesRead = srcFile.Read(buffer, 0, buffer.Length);
                if (srcBytesRead > 0)
                {
                    // write to the mid file
                    midFile.Write(buffer, 0, srcBytesRead);
                    // now read from mid and write to dst
                    midFile.Position = totalBytes;
                    var midBytesRead = midFile.Read(buffer, 0, srcBytesRead);
                    if (midBytesRead != srcBytesRead)
                    {
                        throw new ApplicationException("Error reading Mid file!");
                    }
                    dstFile.Write(buffer, 0, srcBytesRead);
                }
                totalBytes += srcBytesRead;
            }
        }
    }
