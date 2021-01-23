    async Task ParentAsync()
    {
      ... = 0; // Set LogicalCallContext value to "0".
      await ChildAAsync();
      // LogicalCallContext value here is always "0".
      await ChildBAsync();
      // LogicalCallContext value here is always "0".
    }
    async Task ChildAAsync()
    {
      int value = ...; // Save LogicalCallContext value (always "0").
      ... = 1; // Set LogicalCallContext value to "1".
      await Task.Delay(1000);
      // LogicalCallContext value here is always "1".
      ... = value; // Restore original LogicalCallContext value (always "0").
    }
    async Task ChildBAsync()
    {
      int value = ...; // Save LogicalCallContext value (always "0").
      ... = 2; // Set LogicalCallContext value to "2".
      await Task.Delay(1000);
      // LogicalCallContext value here is always "2".
      ... = value; // Restore original LogicalCallContext value (always "0").
    }
