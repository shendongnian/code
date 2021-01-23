    public void ClearAllLocks(Lock LockObj)
    {
        context.Locks.Delete(s => s.UserId == LockObj.UserId);        
        context.SaveChanges();
    }
