    public async Task<JsonResult> DoSomeLongRunningOperation()
    {
      //Do a lot of long running stuff
      var intermediateResult = await DoLongRunningStuff();
      return await DetermineFinalResult(intermediateResult);
    }
