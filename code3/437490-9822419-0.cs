    public interface ICommand
    {
    
    }
    
    public interface ICommandProvider
    {
    	TCommand Create<TCommand>()
    		where TCommand : ICommand;
    	
    }
    
    public interface IQuery<TResult> : ICommand
    {
    	TResult Execute();
    }
    
    public class NhCommand : ICommand
    {
    	// plumbing stuff here, like finding the current session
    }
    
    public class DelinquentAccountViewModel
    {
    	public string AccountName { get; set; }
    	public decimal Amount { get; set; }
    }
    
    public interface IDelinquentAccountsQuery : IQuery<IEnumerable<DelinquentAccountViewModel>>
    {
    	void AmountGreaterThan(decimal amount);
    	// you could define members for specifying sorting, etc. here
    }
    
    public class DelinquentAccountsQuery : NhCommand
    {
    	public IEnumerable<DelinquentAccountViewModel> Execute()
    	{
    		// build HQL and execute results, resulting in a list of DelinquentAccountViewModels
    		// using _amountGreaterThan as a parameter
    		return null;
    	}
    	
    	private Decimal _amountGreaterThan;
    	
    	public void AmountGreaterThan(Decimal amount)
    	{
    		_amountGreaterThan = amount;
    	}
    }
