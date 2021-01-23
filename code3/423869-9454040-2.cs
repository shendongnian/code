    class AccountViewModel
    {
    	public AccountViewModel(Account aWrappedModel)
    	{
    	}
    	
    	string Name {get {return Model.Name;} }
    	
    	AddressObject Address { get{ return new AddressObject( Model.Address ); }
    }
