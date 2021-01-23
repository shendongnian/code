    foreach (var file in Directory.EnumerateFiles(path).AsParallel())
    {
        try
        {
            foreach (var arr in File.ReadLines(file).AsParallel())
            {
                // one more try here?
                foreach (var str in arr)
                {
                    if (str.Contains(pattern))
                    {
                        yield return new 
                        {
                            FileName = file, // file containing matched string
                            Line = str // matched string
                        };
                    }
                }
            }
        }
        catch (SecurityException)
        {
            // swallow or log
        }
    }
