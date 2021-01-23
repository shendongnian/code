    private void SaveFile(HttpPostedFile file, string path)
    {
        Int32 fileLength = file.ContentLength;
        string fileName = file.FileName;
        byte[] buffer = new byte[fileLength];
        file.InputStream.Read(buffer, 0, fileLength);
        using (FileStream newFile = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            newFile.Write(buffer, 0, buffer.Length);
        }
    }
