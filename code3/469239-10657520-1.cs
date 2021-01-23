    // Write our new data to a temp file and read the old file On The Fly
    var temp = Path.GetTempFileName();
    try
    {
        File.WriteAllLines(
            temp,
            File.ReadLines(path)
                .Where(
                   ll => ll.IndexOf(user, StringComparison.OrdinalIgnoreCase) >= 0));
        File.Copy(temp, path, true);
    }
    finally
    {
        File.Delete(temp);
    }
