    private static byte[] buffer = new byte[100000];
    private string ReadFile(string filePath)
    {
        FileStream strm = new FileStream(filePath, FileMode.Open, FileAccess.Read,
        FileShare.Read, 1024, FileOptions.Asynchronous);
        // Make the asynchronous call
        IAsyncResult result = strm.BeginRead(buffer, 0, buffer.Length, new 
        AsyncCallback(CompleteRead), strm);
        //AsyncWaitHandle.WaitOne tells you when the operation is complete
        result.AsyncWaitHandle.WaitOne();
        
        //After completion, your know your data is in your buffer
        Console.WriteLine(buffer);
        //Close the handle
        result.AsyncWaitHandle.Close();
    }
    private void CompleteRead(IAsyncResult result)
    {
        FileStream strm = (FileStream)result.AsyncState;
        int size = strm.EndRead(result);
        strm.Close();
    }
