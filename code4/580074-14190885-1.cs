    void CommandInvokedHandler(IUICommand command)
    {
        // Display message showing the label of the command that was invoked
        switch (command.Label)
        {
            case "Yes":
                var rootPage = this;
                if (rootPage.EnsureSnapped())
                    _currentChoice = SaveChoice.Save;
                break;
            case "No":
                _currentChoice = SaveChoice.DoNotSave;
                break;
            default:
                _currentChoice = SaveChoice.Undefined;
                // Not sure what to do, here.
                break;
        }
    }
