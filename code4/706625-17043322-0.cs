    async Task DoSomething()
    {
      var someObject = SomeService.Get(...);
      using (var check = new SanityCheckScope())
      {
        check.StopWhen(() => someObject.Lifetime < 0);
        await SomeOtherStuff().WithChecks();
      }
    }
