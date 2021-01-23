            EventLog testEventLog = this.EventLog;
            //Or if you are not using windows service, then:
            //EventLog testEventLog = new EventLog();
            testEventLog.Source = "TestServiceSource";
            testEventLog.Log = "TestServiceLog";
			bool eventSourceExists = false;
			try
			{
				eventSourceExists = System.Diagnostics.EventLog.SourceExists(testEventLog.Source);
			}
			catch(System.Security.SecurityException)
			{			
				eventSourceExists = fasle;
			}
			
            //If log source doesn't exists create new one
            if (!eventSourceExists)
            {
                System.Diagnostics.EventLog.CreateEventSource(testEventLog.Source, testEventLog.Log);
            }
