    int nTotalRead = 0;
    HttpWebRequest theRequest;
    HttpWebResponse theResponse;
    ...
    byte[] readBytes = new byte[1024];
    int bytesRead = theResponse.GetResponseStream.Read(readBytes, 0, 4096);
    nTotalRead += bytesread;
    int percent = (int)((nTotalRead * 100.0) / length);
