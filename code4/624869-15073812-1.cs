    var percentSplit = (int)(info.Length * 50 / 100); // extract 50% of file
    var buffer = new byte[8192];
    using (Stream input = File.OpenRead(info.FullName))
    using (Stream output = File.OpenWrite(splitName))
    {
    	int bytesRead = 1;
        while (percentSplit > 0 && bytesRead > 0)
        {
    		bytesRead = input.Read(buffer, 0, Math.Min(percentSplit, buffer.Length));
            output.Write(buffer, 0, bytesRead);
            percentSplit -= bytesRead;
        }
        output.Flush();
    }
