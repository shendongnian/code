    // System.IO.Path
    private static readonly int MaxDirectoryLength = 255;
    // ...
    if (num8 - num5 > Path.MaxDirectoryLength)
    {
        throw new PathTooLongException(Environment.GetResourceString("IO.PathTooLong"));
    }
    // ...
