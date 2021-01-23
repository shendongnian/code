    /// <summary>
	/// User defined async state for SendEmailAsync method
	/// </summary>
	public class SendAsyncState {
		/// <summary>
		/// Contains all info that you need while handling message result
		/// </summary>
		public IEmailMessageInfo EmailMessageInfo { get; private set; }
		public SendAsyncState(IEmailMessageInfo emailMessageInfo) {
			EmailMessageInfo = emailMessageInfo;
		}
	}
