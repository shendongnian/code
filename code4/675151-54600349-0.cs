    ...
 
    public bool CanClose { get; set; }
 
    private RelayCommand closeCommand;
    public ICommand CloseCommand
    {
        get
        {
            if(closeCommand == null)
            (
                closeCommand = new RelayCommand(param => Close(), param => CanClose);
            )
        }
    }
 
    public void Close()
    {
        this.Close();
    }
 
    ...
