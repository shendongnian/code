    private readonly ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();
    private XmlDocument ReadFromFile()
    {
        XmlDocument result = null;
        var fileSystemPath = FileSystemPath();          
        readerWriterLockSlim.EnterReadLock();
        try
        {
            result = new XmlDocument();
            using (var streamReader = new StreamReader(fileStream))
            {
                result.Load(streamReader);
            }
        }
        catch (FileNotFoundException)
        {
            result = null;
        }
        finally
        {
            readerWriterLockSlim.ExitReadLock();
        }
        return result;
    }
    
    
    private void WriteToFile()
    {
        var fileSystemPath = FileSystemPath();            
        readerWriterLockSlim.EnterWriteLock();
        try
        {
            using (var streamWriter = new StreamWriter(fileSystemPath))
            {
                stuff.Save(streamWriter);
            }
        }
        finally
        {
            readerWriterLockSlim.ExitWriteLock();
        }
    }
