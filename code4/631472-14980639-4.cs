    try
    {
        DBConnection.Save();
    }
    catch
    {
        // Roll back the DB changes so they aren't corrupted on ANY exception
        DBConnection.Rollback();
        // Re-throw the exception, it's critical that the user knows that it failed to save
        throw;
    }
