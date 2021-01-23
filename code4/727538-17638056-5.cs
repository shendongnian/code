    public static class YourSyncLockClassExtensions {
    
        public static async Task<OperationSyncLockWrapper> GetSyncLockWrapperInstanceAsync
                                                            (this YourSyncLockClass _syncLock)
        {
            OperationSyncLockWrapper syncLock = new OperationSyncLockWrapper(_syncLock);
            await syncLock.Wait();
    
            return syncLock;
        }
    }    
