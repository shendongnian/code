    private void SetFileToZero(string inputFile)
    {
        string tempFile = Path.Combine(Path.GetDirectoryName(inputFile, "saved.bin"));
        if(File.Exists(tempFile)) File.Delete(tempFile);
        FileInfo fi = new FileInfo(inputFile);
        int pos = Convert.ToInt32(fi.Length) - 4;
        string name = fi.FullName;
        // Move the input file to "saved.bin"
        fi.MoveTo(tempFile);
          
        // Create a zero byte length file with the requested name
        using(FileStream st = File.Create(name))
        {
          // Write a zero byte at the position that is 4 byte less than the required size
          UTF8Encoding utf8 = new UTF8Encoding();
          BinaryWriter bw = new BinaryWriter(st, utf8);
          bw.Seek(pos, SeekOrigin.Begin);
          bw.Write(0);
        }
    }
