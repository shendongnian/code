    public void SetSource(Stream stream)
    {
        if (stream == null)
        {
            throw new ArgumentNullException("stream");
        }
        if (stream.GetType() != typeof(IsolatedStorageFileStream))
        {
            throw new NotSupportedException("Stream must be of type IsolatedStorageFileStream");
        }
        IsolatedStorageFileStream stream2 = stream as IsolatedStorageFileStream;
        stream2.Flush();
        stream2.Close();
        this.Source = new Uri(stream2.Name, UriKind.Absolute);
    }
