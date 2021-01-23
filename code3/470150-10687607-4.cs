    public Task<ParticipantDataModel> GetParticipantInfo(string planNumber, string participantID)
    {
      var instance = new GetParticipantInfo_A(GetParticipantInfoAsync);
      var main = Task<ParticipantDataModel>.Factory.FromAsync(
        instance.BeginInvoke, 
        instance.EndInvoke, 
        participantID, 
        planNumber, 
        serviceContext,
        null);
      var continuation = main.ContinueWith(
        task =>
        {
          lock (_cacheManager)
          {
            _cacheManager.SetCache(planNumber, CacheKeyName.GetPartInfo.ToString(), task.Result);
          }
        });
      return continuation;
    }
