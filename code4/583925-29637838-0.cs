        protected void Application_Error(object sender, EventArgs e)
		{		
			Exception ex = Server.GetLastError();
			
			if (ex is ThreadAbortException)
			{
				// Nothing to do here. The thread abended.
			}
			else
			{
				activityMgr.Add(System.Reflection.MethodBase.GetCurrentMethod(), ex);
			}
		}
