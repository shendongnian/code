    try
    {
        await ApplicationData.Current.LocalFolder.GetFileAsync(FirstRunFile);
    }
    catch (FileNotFoundException)
    {
        isFirstRun = true;
    }
    
    if (isFirstRun) {
        // Perform necessary initialization here
        await ApplicationData.Current.LocalFolder.CreateFileAsync(FirstRunFile);
    }
