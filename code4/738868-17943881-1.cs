    public static DataSet CopyAndSort(this DataSet ds, string column)
    {
        DataSet newDs = ds.Copy();
    
        //sorting occurs
        return newDs; // No need to copy it *again*.
    }
