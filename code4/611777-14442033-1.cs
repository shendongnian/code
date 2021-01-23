    private MyCommand simpleCommand;
    public MyCommand SimpleCommand
    {
        get { return simpleCommand; }
        set { simpleCommand = value; }
    }
    public MainViewModel()
    {
        SimpleCommand = new MyCommand(new Action<bool>(DoSomething));
    }
    public void DoSomething(bool isChecked)
    {
        //something
    }
