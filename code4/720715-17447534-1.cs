    class MyEntryViewModel : INotifyPropertyChanged
    {
    	public MyEntryViewModel()
    	{
    		UpVoteCommand = new DelegateCommand(OnUpVoteCommand);
    	}
    	public int Votes 
    	{
    		get {return mVotes;}
    		set {mVotes = value; RaiseProperty("Votes");}
    	}
    	
    	public ICommand UpVoteCommand 
    	{
    		get; private set;
    	}
    	
    	void OnUpVoteCommand(object aParameter)
    	{
    		Votes++;
    	}
    }
