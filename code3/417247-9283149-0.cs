	public class EmailSender {
		private int _currentRetryCount;
		private int _maxRetryCount;
		private MailMessage _mailMessage;
		private bool _isAlreadyRun;
		public event SendEmailCompletedEventHandler SendEmailCompleted;
		public void SendEmailAsync(MailMessage message, int retryCount) {
			if (_isAlreadyRun) {
				throw new InvalidOperationException(
                  "EmailSender doesn't support multiple concurrent invocations."
                );
			}
			_isAlreadyRun = true;
			_maxRetryCount = retryCount;
			_mailMessage = message;
			SmtpClient client = new SmtpClient();
			client.SendCompleted += SmtpClientSendCompleted;
			SendMessage(client);
		}
		private void SendMessage(SmtpClient client) {
			try {
				client.SendAsync(_mailMessage, Guid.NewGuid());
			} catch (Exception exception) {
				EndProcessing(client);
			}
		}
		private void EndProcessing (SmtpClient client) {
			if (_mailMessage != null) {
				_mailMessage.Dispose();
			}
			if (client != null) {
				client.SendCompleted -= SmtpClientSendCompleted;
				client.Dispose();
			}
			OnSendCompleted(
               new SendEmailCompletedEventArgs(null, false, null, _currentRetryCount)
            );
			_isAlreadyRun = false;
			_currentRetryCount = 0;
		}
		private void SmtpClientSendCompleted(object sender, AsyncCompletedEventArgs e) {
			var smtpClient = (SmtpClient)sender;
			if(e.Error == null || _currentRetryCount >= _maxRetryCount) {
				EndProcessing(smtpClient);
			} else {
				_currentRetryCount++;
				SendMessage(smtpClient);
			}
		}
		protected virtual void OnSendCompleted(SendEmailCompletedEventArgs args) {
			var handler = SendEmailCompleted;
			if (handler != null) {
				handler(this, args);
			}
		}
	}
	public delegate void SendEmailCompletedEventHandler(
       object sender, SendEmailCompletedEventArgs e);
	public class SendEmailCompletedEventArgs : AsyncCompletedEventArgs {
		public SendEmailCompletedEventArgs(
			Exception error,
			bool canceled,
			object userState,
			int retryCount)
			: base(error, canceled, userState) {
			RetryCount = retryCount;
		}
		public int RetryCount { get; set; }
	}}
