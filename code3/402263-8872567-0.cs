    private DelegateCommand _runCommand;
	public DelegateCommand RunCommand
	{
		get
		{
            if (_runCommand == null)
                _runCommand = new DelegateCommand(Run, CanRun);
	        
            return _runCommand;
		}
	}
    void Run()
	{
	    ...	
	}
	bool CanSaveAction()
	{
		return true;
	}
