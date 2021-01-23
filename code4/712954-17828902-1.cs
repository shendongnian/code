	APMState initialState = ar.AsyncState as APMState;
	DependentTransaction  dtx = initialState.Transaction;
	if (dtx.TransactionInformation.Status != TransactionStatus.Aborted)
	{
		using (TransactionScope scope = new TransactionScope (dtx))
		{
			ae.Result = ((IMyService)initialState.Proxy).EndDoSomeTransactionalWork(ar);
			scope.Complete();
		}
		dtx.Complete();
	}
	else
	{
		log.Error(@" The transaction has aborted :-(");
		log.Debug(@" --> Calling EndDoSomeTransactionalWork on proxy outside a transaction scope to retreive the WCF fault :-)");
		ae.Result = ((IMyService)initialState.Proxy).EndDoSomeTransactionalWork(ar);
	}
