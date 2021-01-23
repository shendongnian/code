		public void Function_X(Func<object,..> func)
		{
			if (IsDebugEnabled)
			{
					Logger("Start DataLibrary: FUNC-X");
			}
			try
			{
				CheckInitSucceeded();
			
				GetAuthenticationTokens();
			
				var dm = new Manager();
			
				/**
				* THIS SINGLE LINE IS THE VARIABLE PART
				**/
			//    var output = dm.FUNC-X(...);
				var output = func(...);
			
				if (IsDebugEnabled)
				{
					var data = Serialize(output);
					Logger(output);
				}
				return output;
			}
			catch (WebFaultException)
			{
				throw;
			}
			catch (OtherException ex)
			{
				if (Logger.IsErrorEnabled)
				{
					Logger.LogError("Exception in FUNC-X", ex);
				}
				throw new OtherException("Some Message");
			}
			catch (Exception ex)
			{
				if (IsErrorEnabled)
				{
					Logger("Exception in FUNC-X", ex);
				}
			
				throw new Exception("Generic Exception");
			}
			finally
			{
				if (IsDebugEnabled)
				{
					Logger("End FUNC-X");
				}
			}
		}
