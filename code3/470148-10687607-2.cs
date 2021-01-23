    public void GetParticipantInfo(string planNumber, string participantID)
    {
      var instance = new GetParticipantInfo_A(GetParticipantInfoAsync);
      Task<ParticipantDataModel>.Factory.FromAsync(
        instance.BeginInvoke, 
        instance.EndInvoke, 
        participantID, 
        planNumber, 
        serviceContext,
        null).ContinueWith(
        task =>
        {
          _cacheManager.SetCache(planNumber, CacheKeyName.GetPartInfo.ToString(), task.Result);
        });
    }
