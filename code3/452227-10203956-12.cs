    private bool FooCondition(int x)
    {
       // complex condition here
    }
    
    private string BarAction(int x)
    {
        // complex action here
    }
    
    private void button2_Click()
    {
        DoSomething(FooCondition, BarAction);
    }
