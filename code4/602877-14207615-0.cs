    // Use [InternalsVisibleTo] to share internal methods with the unit test project.
    internal async Task DoLookupCommandImpl(long idToLookUp)
    {
      IOrder order = await orderService.LookUpIdAsync(idToLookUp);   
      // Close the search
      IsSearchShowing = false;
    }
    private async void DoStuff(long idToLookUp)
    {
      await DoLookupCommandImpl(idToLookup);
    }
