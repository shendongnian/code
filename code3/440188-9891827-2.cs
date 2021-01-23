    try
    {
        using (var input = File.Open(inputFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
        using (var thumb = File.Open(thumbFilename, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            Thumbnail(input, thumb, 200, 100);
        }
    }
    catch (MyException)
    {
        File.Delete(thumbFilename);
    }
