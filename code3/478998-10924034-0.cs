    public void subscribeUserEndPoint(ContactGroupServices cntGrpSvcs)
    {
      try
      {
        cntGrpSvcs.EndSubscribe(cntGrpSvcs.BeginSubscribe(null, null));
        CollaborationSubscriptionState state = cntGrpSvcs.CurrentState;
        LOG.Info("Subscribed State = " + state.ToString());
        LOG.Info("Returning from Successful Subscribe Endpoint");
      }
      catch (Exception ex)
      {
        LOG.Error("Failed to Complete Subscribe. Exception: " + ex.ToString());
      }   
    }
