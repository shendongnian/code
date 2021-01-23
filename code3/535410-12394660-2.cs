    [CommandMethod("MYCMD", CommandFlags.Modal)]
    public void MyCommand()
    {
      ExecuteCommand<MyCommand>();
    }
