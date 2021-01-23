    private void SetFileToZero(string inputFile)
    {
        // Remove previous backup file
        string tempFile = Path.Combine(Path.GetDirectoryName(inputFile), "saved.bin");
        if(File.Exists(tempFile)) File.Delete(tempFile);
        // Get current length of input file (minus 4 byte)
        FileInfo fi = new FileInfo(inputFile);
        int pos = Convert.ToInt32(fi.Length) - 4;
        string name = fi.FullName;
        // Move the input file to "saved.bin"
        fi.MoveTo(tempFile);
          
        // Create a zero byte length file with the requested name
        using(FileStream st = File.Create(name))
        {
          // Position the file pointer at a position 4 byte less than the required size
          UTF8Encoding utf8 = new UTF8Encoding();
          BinaryWriter bw = new BinaryWriter(st, utf8);
          bw.Seek(pos, SeekOrigin.Begin);
          // Write the last 4 bytes
          bw.Write(0);
        }
    }
