    public static void UploadFile(this Browser browser, string uploadPath)
    {
        var trw = new TreeWalker(Condition.TrueCondition);
        var mainWindowElement = trw.GetParent(AutomationElement.FromHandle(browser.hWnd));
        // Wait for the dialog to open
        Thread.Sleep(1000);
        // Get the select dialog
        var selectDialogElement = mainWindowElement.FindFirst(TreeScope.Descendants, 
            new PropertyCondition(AutomationElement.NameProperty, "Choose File to Upload"));
        // Get the file name box and set the path
        var selectTextElement = selectDialogElement.FindFirst(
            TreeScope.Descendants,
            new AndCondition(new PropertyCondition(AutomationElement.NameProperty, "File name:"),
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit)));
        var selectValue = (ValuePattern)selectTextElement.GetCurrentPattern(ValuePattern.Pattern);
        selectValue.SetValue(uploadPath);
        // Get the open button and click it
        var openButtonElement = selectDialogElement.FindFirst(TreeScope.Descendants,
            new AndCondition(new PropertyCondition(AutomationElement.NameProperty, "Open"),
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button)));
        var openButtonClick = (InvokePattern)openButtonElement.GetCurrentPattern(InvokePattern.Pattern);
        openButtonClick.Invoke();
    }
