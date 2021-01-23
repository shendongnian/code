    using (var stream = new IsolatedStorageFileStream("file." + fileext,
                                                      FileMode.Create, file))
    {
        byte[] buffer = new byte[1024];
        int bytesRead;
        while ((bytesRead = e.Result.Read(buffer, 0, buffer.Length)) > 0)
        {
            stream.Write(buffer, 0, bytesRead);
        }
    }
