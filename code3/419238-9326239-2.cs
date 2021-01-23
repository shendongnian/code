    public DbManager openDB()
    {
        CopyDB(...);
        try
        {
            mDb = dataHelper.WritableDatabase;
        }
        catch(Exception e) 
        {
        }
        return this;
    }
