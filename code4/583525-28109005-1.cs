    Process process = new Process();
    process.StartInfo.FileName = mysqlexepath;
    process.StartInfo.Arguments = "-v -u user -ppassworddbname";
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardInput = true;
    
	byte[] buffer = new byte[4096]; 
    int count;
    try
    {
        process.Start();
        BinaryWriter stdinBinary = new BinaryWriter(process.StandardInput.BaseStream);
        Stream fileStream;
		if (sqlfilepath.EndsWith(".gz")) {
             fileStream = new GZipStream(new FileStream(sqlfilepath, FileMode.Open, FileAccess.Read, FileShare.Read), CompressionMode.Decompress); 
        } else {
             fileStream = new FileStream(sqlfilepath, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
        using (fileStream)
        {
            while ((count = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                if (process.HasExited == true)
                    throw new Exception("DB went away.");
    
                stdinBinary.Write(buffer, 0, count);
                stdinBinary.Flush(); // probably not needed
            }
        }
        stdinBinary.Flush();
        process.Close();
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine(ex.Message);
    }
