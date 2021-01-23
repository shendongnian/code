    public byte[] GetFile(string filename)
    {
      byte[] binFile = null;
      try
      {
        using (var aStream = File.Open(filename, FileMode.Open, FileAccess.Read))
        {
          BinaryReader binReader = new BinaryReader(aStream);
          binFile = new byte[binReader.BaseStream.Length];
          binReader.BaseStream.Position = 0; // <= this step should not be necessary
          binFile = binReader.ReadBytes(binReader.BaseStream.Length);
          binReader.Close();
        }
      } catch (IOException err) {
        // file is being used by another process.
      } catch (ObjectDisposedException err) {
        // I am guessing you would never see this because your binFile is not disposed
      }
      return binFile;
    }
