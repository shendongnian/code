    /// <summary>
    /// SET - DELETE all record by table - no truncate - return deleted records
    /// </summary>
    public static int setListDelAllMYTABLE()
    {
        // INIT
        int retObj = 0;
        using (MYDBEntities ctx = new MYDBEntities())
        {
            // GET - all record
            var tempAllRecord = ctx.MYTABLE.ToList();
            // RESET
            ctx.MYTABLE.RemoveRange(tempAllRecord);
            // SET - final save
            retObj += ctx.SaveChanges();
        }
        // RET
        return retObj;
    }
