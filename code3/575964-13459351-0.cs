    // Modify as necessary
    public override void PreExecute()
    {
        base.PreExecute();
        string thePath = Variables.FilePath;
        // Do something ...
    }
    public override void PostExecute()
    {
        base.PostExecute();
        string theNewValue = "";
        // Do something to figure out the new value...
        Variables.FilePath = theNewValue;
    }
    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
        string thePath = Variables.FilePath;
        // Do whatever needs doing here ...
    }
