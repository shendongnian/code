    // Use a named EventWaitHandle to determine if the application is already running.
    bool eventWasCreatedByThisInstance;
    using (new EventWaitHandle(false, EventResetMode.ManualReset, Application.ProductName, out eventWasCreatedByThisInstance))
    {
        if (eventWasCreatedByThisInstance)
        {
            runTheProgram();
            return;
        }
        else // This instance didn't create the event, therefore another instance must be running.
        {
            return; // Display warning message here if you need it.
        }
    }
