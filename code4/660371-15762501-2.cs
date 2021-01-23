    foreach( var abuseCase in abuseCases )
    {
      foreach( var acs in abuseCase.AbuseCaseStatuses )
      {
        acs.AbuseCaseStatus.Status = acs.Status;
      }
    }
