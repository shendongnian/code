    public class APMState
    {
    	public IClientChannel Proxy { get; set; }
    	public OperationContext Identity { get; set; } 
    	public DependentTransaction Transaction { get; set; }	
    }
	Transaction tx = Transaction.Current;
	try
	{
		DependentTransaction dtx = tx.DependentClone(DependentCloneOption.BlockCommitUntilComplete);
		// There is no need for a TransactionScope here, the one set by the calling method is used.
		((IMyService)proxy).BeginDoSomeTransactionalWork(..., new APMState{ Identity = OperationContext.Current, Proxy = proxy, Transaction = dtx});
	}
	catch (TransactionAbortedException tae)
	{
	}  
