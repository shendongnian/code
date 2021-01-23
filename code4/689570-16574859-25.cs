	public class Logic
	{
		private readonly Func<ITransactionContext> createContext;
		private readonly Func<ITransactionContext, UpdateHelper> createHelper; 
		public Logic(Func<ITransactionContext> createContext, 
			Func<ITransactionContext, UpdateHelper> createHelper)
		{
			this.createContext = createContext;
			this.createHelper = createHelper;
		}
		public int UpdateEmployee(Employee employeeData)
		{
			using (var context = createContext())
			{
				var request = new UpdateRequest();
				request.Commands.Add(new Command(UpdateCommandType.Update, employeeData, new EmployeeMapping()));
				var helper = createHelper(context);
				var response = helper.Update(request);
				return response.TransactionId ?? 0;
			}
		}
	}
     
