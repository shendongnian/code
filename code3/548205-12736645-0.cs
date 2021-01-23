    		public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			DialogResult result = DialogResult.Abort;
			try
			{
				Exception ex = (Exception)e.Exception;
				result = MessageBox.Show("Whoops! Please contact the developers with the"
				 + " following information:\n\n" + e.Exception.Message + e.Exception.StackTrace,
				 "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
			}
			finally
			{
				if (result == DialogResult.Abort)
				{
					Application.Exit();
				}
			}
		}
