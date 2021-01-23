	internal static class Extension
	{
		private static void TransferCompletion<T>(
			TaskCompletionSource<T> tcs, System.ComponentModel.AsyncCompletedEventArgs e, 
            Func<T> getResult)
		{
			if (e.Error != null)
			{
				tcs.TrySetException(e.Error);
			}
			else if (e.Cancelled)
			{
				tcs.TrySetCanceled();
			}
			else
			{
				tcs.TrySetResult(getResult());
			}
		}
		public static Task<loginCompletedEventArgs> LoginAsyncTask(
            this YChatWebService.WebServiceControllerPortTypeClient client,
            string userName, string password)
		{
			var tcs = new TaskCompletionSource<loginCompletedEventArgs>();
			client.loginCompleted += (s, e) => TransferCompletion(tcs, e, () => e);
			client.loginAsync(userName, password);
			return tcs.Task;
		}
	}
