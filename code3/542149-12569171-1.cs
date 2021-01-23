	if (finalInfo == null) // still have no finalInfo
	{
		_serverService.GetLatestFinalInfo((response, theFinalInfo) =>
				                            {
												Trace.WriteLine(myStruct.i);
				                            if (!_timedOut) // this could be changed elsewhere in the class while we're waiting for the server response
				                            {
				                                if (response == ServerResponse.Successful)
				                                {
				                                  	_databaseService.AddFinalInfo(theFinalInfo);
				                                  	// navigate to next screen
				                                }
				                                else
				                                {
				                                  	// do something else
				                                }
				                            }
				                            });
	}
			}
