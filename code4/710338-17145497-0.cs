    public void RegisterEvent()
    {
        // This overrides mock you set in test
        // Printer = new ActionClass ();
        Printer.PrintPage += Printer.ActionClass_PrintPage;
    }
