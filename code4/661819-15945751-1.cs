    public class WorkerThread
    {
        public void DoWork(DependentTransaction dependentTransaction)
        {
            Thread thread = new Thread(ThreadMethod);
            thread.Start(dependentTransaction); 
        }
        public void ThreadMethod(object transaction) 
        { 
            DependentTransaction dependentTransaction = transaction as DependentTransaction;
            Debug.Assert(dependentTransaction != null);
            try
            {
                using(TransactionScope ts = new TransactionScope(dependentTransaction))
                {
                    /* Perform transactional work here */ 
                    ts.Complete();
                }
            }
            finally
            {
                dependentTransaction.Complete(); 
                dependentTransaction.Dispose(); 
            }
        }
    //Client code 
    using(TransactionScope scope = new TransactionScope())
    {
        Transaction currentTransaction = Transaction.Current;
        DependentTransaction dependentTransaction;    
        dependentTransaction = currentTransaction.DependentClone(DependentCloneOption.BlockCommitUntilComplete);
        WorkerThread workerThread = new WorkerThread();
        workerThread.DoWork(dependentTransaction);
        /* Do some transactional work here, then: */
        scope.Complete();
    }
