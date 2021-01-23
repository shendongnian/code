	public class UpdateHelper
	{
		private readonly ITransactionContext transactionContext;
		public UpdateHelper(ITransactionContext transactionContext)
		{
			this.transactionContext = transactionContext;
		}
		public UpdateResponse Update(UpdateRequest request)
		{
			this.transactionContext.BeginTransaction(IsolationLevel.RepeatableRead);
			var response = new UpdateResponse();
			foreach (var command in request.Commands)
			{
				try
				{
					response = command.PerformAction(transactionContext);
					if (response.Status != UpdateStatus.Success)
					{
						this.transactionContext.RollbackTransaction();
						return response;
					}
				}
				catch (Exception ex)
				{
					this.transactionContext.RollbackTransaction();
					return HandleException(command, ex);
				}
			}
			this.transactionContext.CommitTransaction();
			return response;
		}
		private UpdateResponse HandleException(Command command, Exception exception)
		{
			Logger.Log(exception);
			return new UpdateResponse { Status = UpdateStatus.Error, Message = exception.Message, LastCommand = command };
		}
	}
