    public static class OperationSyncLockWrapperFactory {
    
        public static async Task<OperationSyncLockWrapper> GetInstace(YourSyncLockClass _syncLock)
        {
            OperationSyncLockWrapper syncLock = new OperationSyncLockWrapper(_syncLock);
            await syncLock.Wait();
    
            return syncLock;
        }
    }    
 
