    for (int i = 0; i < 10; i++)
    {
        try {
            File.Move(logFilePath, tempPathOnRemoteServer);
        } catch (Exception) { 
            if (i == 9)
                throw new Exception("Could not acquire lock");
            System.Threading.Thread.Sleep(1000 * (i+1)); }
    }
    File.Copy(tempPathOnRemoteServer, endPathOnLocalHost);
