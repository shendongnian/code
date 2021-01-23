    if (args.PreviousExecutionState == ApplicationExecutionState.ClosedByUser)
                {
    
                    IReadOnlyList<StorageFile> thefiles;
    
                    var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                    Windows.Globalization.DateTimeFormatting.DateTimeFormatter formatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");
                    thefiles = await localFolder.GetFilesAsync();
    
                    foreach (var f in thefiles)
                    {
                        await f.DeleteAsync(StorageDeleteOption.Default);
                    }
                }
