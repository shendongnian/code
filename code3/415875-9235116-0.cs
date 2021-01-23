    /// <summary>
    /// Do something useful with a completed query
    /// </summary>
    /// <param name="result"></param>
    /// <returns>
    ///   true if the query failed;
    ///   false if the query was successful
    /// </returns>
    private static bool DoSomethingUseful( IAsyncResult result )
    {
        throw new NotImplementedException() ;
    }
        
    static void Main( string[] args )
    {
        List<IAsyncResult> batch         = SpawnBatch() ;
        bool               errorOccurred = ProcessCompletedBatches( batch , DoSomethingUseful) ;
            
        if ( errorOccurred )
        {
            CancelPending( batch ) ;
        }
            
        return ;
            
    }
        
    public static bool ProcessCompletedBatches( List<IAsyncResult> pending , Func<IAsyncResult,bool> resultHandler )
    {
        bool errorOccurred = false ;
            
        while ( ! errorOccurred && pending.Count > 0 )
        {
            WaitHandle[] inFlight = pending.Select( x => x.AsyncWaitHandle ).ToArray() ;
                
            int offset = WaitHandle.WaitAny( inFlight ) ;
                
            IAsyncResult result = pending[offset] ;
            pending.RemoveAt(offset) ;
                
            errorOccurred = resultHandler(result) ; // result handler should  throw an InvalidOperationException if the batched query failed
                
        }
            
        return errorOccurred ;
            
    }
