    using System.IO;
    // ...
    public DImage(Stream Stream)
    {
        using (var reader = new StreamReader(Stream))
        {
            // Read the image.
        }
    }
    public DImage(byte[] Bytes) 
        : this(new MemoryStream(Bytes))
    {
    }
    public DImage(string FileName) 
        : this(new FileStream(FileName, FileMode.Open, FileAccess.Read))
    {
    }
