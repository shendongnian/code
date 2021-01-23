    public void Dispose()
		{
			// The following code is from: http://www.vasylevskyi.com/2010/11/correct-wcf-client-proxy-closing.html
			try
			{
				if (this.State != CommunicationState.Closed && this.State != CommunicationState.Faulted)
				{
					((ICommunicationObject)this).BeginClose(
						(asr) =>
						{
							try
							{
								((ICommunicationObject)this).EndClose(asr);
							}
							catch
							{
								this.Abort();
							}
						}, null
					);
				}
				else
				{
					this.Abort();
				}
			}
			catch (CommunicationException)
			{
				this.Abort();
			}
