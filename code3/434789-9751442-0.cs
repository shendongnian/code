    private void SendReceivedDataToFile(int sendBytes)
    {
		using (var fs = new FileStream(tbSaveDirectory.Text, FileMode.Append))
			fs.Write(oldData, 0, sendBytes);
		readByteCount += sendBytes;
    }
