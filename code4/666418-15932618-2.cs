    string inputFilename = "inputFile.txt";
    string outputFilename = "outputFile.txt";
    using (ofile = File.OpenWrite(outputFilename))
    {
        using (ifile = File.OpenRead(inputFilename))
        {
            int bufferSize = 4096;
            byte[] buffer = new byte[bufferSize];
            long filePos = ifile.Length;
            do
            {
                long newPos = Math.Max(0, filePos - bufferSize);
                int bytesToRead = (int)(filePos - newPos);
                ifile.Seek(newPos, SeekOrigin.Set);
                int bytesRead = ifile.Read(buffer, 0, bytesToRead);
                // write the buffer to the output file, in reverse
                for (int i = bytesRead-1; i >= 0; --i)
                {
                    ofile.WriteByte(buffer[i]);
                }
                filePos = newPos;
            } while (filePos > 0);
        }
    }
