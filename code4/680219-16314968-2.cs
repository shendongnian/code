    public ICommand MyButtonClickCommand 
    {
        get { return new DelegateCommand(FuncToCall, FuncToEvaluate); }
    }
    
    private object FuncToCall(object context)
    {
        //this is called when the button is clicked
    }
    
    private bool FuncToEvaluate(object context)
    {
        //this is called to evaluate whether FuncToCall can be called
        //for example you can return true or false based on some validation logic
        return true;
    }
    
    
    
    <Button x:Name="myButton" Command="{Binding MyButtonClickCommand}" />
