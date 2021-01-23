    public void ClearAllLocks(Lock LockObj)
    {
        var locksToDelete = context.Locks.Where(s => s.UserId == LockObj.UserId);
 
        foreach(var stf in locksToDelete)
           context.Locks.DeleteObject(stf);
        
        context.SaveChanges();
    }
