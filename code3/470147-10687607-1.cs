    private void YourButton_Click(object sender, EventArgs args)
    {
      var ui = TaskScheduler.FromCurrentSynchronizationContext();
      Task.Factory
        .StartNew(
        () =>
        {
          // You can access UI controls here if necessary.
          GetParticipantInfo(partID, plantID);
        }, ui)
        .ContinueWith(
        (t) =>
        {
          // You can access UI controls here if necessary.
          SetCurrentInvestments(partID, planID);    
        }, ui)
        .ContinueWith(
        (t) =>
        {
          // You can access UI controls here if necessary.
          GetLoanFunds(planID, partID);
        }, ui)
        .ContinueWith(
        (t) =>
        { 
          // Everything is done.
          // You can access UI controls here if necessary.
        }, ui;
    }
