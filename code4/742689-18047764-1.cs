    bool isReadOnly = ((File.GetAttributes(strCreatePath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly);
    if(!isReadOnly)
    {
        try
        {
             Directory.CreateDirectory(strCreatePath);
        } catch (System.UnauthorizedAccessException unauthEx)
        {
            // still the same eception ?!
            Console.Write(unauthEx.ToString());
        }
        catch (System.IO.IOException ex)
        {
            Console.Write(ex.ToString());
        }
    }
