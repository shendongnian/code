    using (var fin = File.Open(InputFilename, FileMode.Open, FileAccess.Read, FileShare.None))
    {
        using (var fout = File.OpenWrite(OutputFilename))`
        {
            int bytesRead = 0;
            var buffer = new byte[65536];
            while ((bytesRead = fin.Read(buffer, 0, buffer.Length)) > 0)
            {
                fout.Write(buffer, 0, bytesRead);
            }
        }
    }
