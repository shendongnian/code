        public class AssemblyService : IAssemblyService
	{
		public Assembly Load(string assemblyName)
		{
			return Assembly.Load(assemblyName);			
		}
	}
	public class CommandService : ICommandService
	{
		private readonly IAssemblyService assemblyService;
		public CommandService(IAssemblyService assemblyService)
		{
			this.assemblyService = assemblyService;
		}
		public CommandOutput Process(string inputCommand, string requestInfo)
		{			
			string commandName = GetAssemblyName(inputCommand);
			
			try
			{
				string args = GetArgs(inputCommand);
	
				Assembly assembly = assemblyService.Load(commandName);
				ICommand command = assemblyService.GetCommand(assembly);
				return command.Execute(args, requestInfo);
			}
			catch (Exception ex)
			{
			    //Log original exception or add to inner exception
				throw new UnknownCommandException(commandName);
			}						
		}
	}
