    // Delete a specific directory.
    string dirDelete = Path.Combine("MyApp1", "SubDir3");
    try
    {
       if (store.DirectoryExists(dirDelete))
       {
          store.DeleteDirectory(dirDelete);
       }
    }
    catch (IsolatedStorageException ex)
    {
       sb.AppendLine(ex.Message);
    }
