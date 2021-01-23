    public static async Task<bool> FileExistsAsync(this StorageFolder folder, string fileName)
    {
        try
        {
            await folder.GetFileAsync(fileName);
            return true;
        }
        catch (FileNotFoundException)
        {
            return false;
        }
    }
