		public UpdateHelper(ITransactionDbContext transactionDbContext,
			ICommandActionFactory commandActionFactory)
		{
			this.transactionDbContext = transactionDbContext;
			this.commandActionFactory = commandActionFactory;
		}		
                
                public UpdateResponse Update(UpdateRequest request)
		{
			  this.transactionDbContext.BeginTransaction(IsolationLevel.RepeatableRead);
			var response = new UpdateResponse();
			foreach (var command in request.Commands)
			{
				try
				{
					var commandAction = this.commandActionFactory.CreateCommandAction(command, this.transactionDbContext);
					response = commandAction.PerformAction(command);
					if (response.Status != UpdateStatus.Success)
					{
						this.transactionDbContext.RollbackTransaction();
						return response;
					}
				}
			
				catch (Exception ex)
				{
					this.transactionDbContext.RollbackTransaction();
					return HandleException(command, ex);
				}
			}
			this.transactionDbContext.CommitTransaction();
			return response;
		}
            }
