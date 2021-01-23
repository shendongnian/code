	public class Command
	{
		private readonly UpdateCommandType type;
		private readonly object data;
		private readonly IDbMapping mapping;
		public Command(UpdateCommandType type, object data, IDbMapping mapping)
		{
			this.type = type;
			this.data = data;
			this.mapping = mapping;
		}
		public UpdateResponse PerformAction(ITransactionContext context)
		{
			var commandBuilder = new CommandBuilder(mapping);
			var result = 0;
			switch (type)
			{
				case UpdateCommandType.Insert:
					result  = context.ExecuteSqlCommand(commandBuilder.InsertSql, commandBuilder.InsertParameters(data));
					break;
				case UpdateCommandType.Update:
					result = context.ExecuteSqlCommand(commandBuilder.UpdateSql, commandBuilder.UpdateParameters(data));
					break;
				case UpdateCommandType.Delete:
					result = context.ExecuteSqlCommand(commandBuilder.DeleteSql, commandBuilder.DeleteParameters(data));
					break;
			}
			return result == 0 ? new UpdateResponse { Status = UpdateStatus.Success } : new UpdateResponse { Status = UpdateStatus.Fail };
		}
	}
