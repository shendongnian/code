		async Task<List<Client>> GetData()
		{
			using (ClientsContext context = new ClientsContext()) // subclass of DbContext
			{
				SqlDependency.Start(context.Database.Connection.ConnectionString);
				SqlDependency dependency = new SqlDependency();
				dependency.OnChange += (sender, e) =>
				{
					Console.Write(e.ToString());
				};
				Task<List<Client>> task = Task<Task<List<Client>>>.Factory.StartNew(async () =>
				{
					System.Runtime.Remoting.Messaging.CallContext.SetData("MS.SqlDependencyCookie", dependency.Id);
					var list = await context.Clients.Where(c => c.FirstName.Length > 0).ToListAsync();
				}).Unwrap();
				return await task;
			}
		}
