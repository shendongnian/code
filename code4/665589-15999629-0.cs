    private void Initialize()
    {
      var dte = GetService(typeof(SDTE)) as EnvDTE.DTE;
      _startCommandEvents = dte.Events.CommandEvents["{5EFC7975-14BC-11CF-9B2B-00AA00573819}", 295];
      _startCommandEvents.BeforeExecute += OnLeaveBreakMode;
    }
    
    private void OnBeforeStartCommand(string guid, int id, object customIn, object customOut, ref bool cancelDefault)
    {
      //your event handler this command
    }
