    public interface IUnitOfWork: IDisposable
    {
    	IGenericTransaction BeginTransaction();
    }
    
    public interface IGenericTransaction: IDisposable
    {
    	void Commit();
    	
        void Rollback();
    }
    
    public class NhUnitOfWork: IUnitOfWork
    {
    	private readonly ISession _session;
    
    	public ISession Session
    	{
    	    get { return _session; }
    	}
    
    	public NhUnitOfWork(ISession session)
    	{
    		_session = session;
    	}
    
    	public IGenericTransaction BeginTransaction()
    	{
    		return new NhTransaction(_session.BeginTransaction());
    	}
    
    	public void Dispose()
    	{
    		_session.Dispose();
    	}
    }
    
    public class NhTransaction: IGenericTransaction
    {
    	private readonly ITransaction _transaction;
    
    	public NhTransaction(ITransaction transaction)
    	{
    		_transaction = transaction;
    	}
    
    	public void Commit()
    	{
    		_transaction.Commit();
    	}
    
    	public void Rollback()
    	{
    		_transaction.Rollback();
    	}
    	public void Dispose()
    	{
    		_transaction.Dispose();
    	}
    }
