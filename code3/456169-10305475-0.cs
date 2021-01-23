    try
    {
        Move(dest, tmp);
        Move(src, dest);
        Delete(tmp);
    }
    catch
    {
        try
        {
            Move(tmp, dest);
        }
        catch
        {
        }
        throw;
    }
