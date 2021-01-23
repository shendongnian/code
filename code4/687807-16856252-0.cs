    private Stream CreateStream(string name, string fileNameExtension, 
      Encoding encoding, string mimeType, bool willSeek)
    {
        Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);
        m_streams.Add(stream);
        //Get all the files
        _emfFiles.Add(name + "." + fileNameExtension);
        return stream;
    }
