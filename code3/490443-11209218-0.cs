    private void CopyFile(string source, string dest)
    {
        using (var input = new FileStream(source, FileMode.Open, FileAccess.Read))
        using (var output = new FileStream(dest, FileMode.OpenOrCreate, FileAccess.Write))
        {
            byte[] data = new byte[1024];
            int bytesRead = 0;
            do
            {
                bytesRead = input.Read(data, 0, data.Length);
                if (bytesRead > 0)
                    output.Write(data, 0, data.Length);
            } while (bytesRead > 0);
        }
    }
