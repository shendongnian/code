    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        int bufferSize = 1024 * 300;
        string filePath = saveFileDialog.FileName;
        if (File.Exists(filePath))
            File.Delete(filePath);
        int totalBytes = 0;
        HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(DownloadUrl);
        long contentLength = webRequest.GetResponse().ContentLength;
        using (Stream webStream = webRequest.GetResponse().GetResponseStream())
        using (StreamReader reader = new StreamReader(webStream))
        using (BinaryWriter fileWriter = new BinaryWriter(File.Create(filePath)))
        {
            do
            {
                char[] buffer = new char[bufferSize];
                bytesRead = reader.ReadBlock(buffer, 0, bufferSize); // also tried with Read(buffer, 0, bufferSize);
                totalBytes += bytesRead;
                Console.WriteLine("Bytes read: " + bytesRead + " Total Bytes: " + totalBytes + " Content length: " + contentLength);
                if (bytesRead > 0)
                    fileWriter.Write(buffer, 0, bytesRead);
            } while (!reader.EndOfStream);
            fileWriter.flush();
        }
    }
