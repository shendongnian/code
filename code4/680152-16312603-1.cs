    bool success = false;
    for (var count = 0; !success && count < 10; ++count)
    {
        try
        {
            File.Move(uploadedPath, savePath);
            success = true;
        }
        catch (IOException)
        {
            Thread.Wait(1000);
        }
    }
