	class ClassA
	{
		public MyTypedFactory Factory { get; set; }
		public ClassB CommandPopulator { get; set; }
		public void Foo()
		{
			List<MyTransientCommand> commands = new List<MyTransientCommand>();
			
			try
			{
				CommandsPopulator.Commands = commands;
				for (int i=0; i<100; ++i)
				{
					CommandsPopulator.Bar();
				}
				foreach (MyTransientCommand command in commands)
				{
					command.Execute();
				}
			}
			finally
			{
				foreach (MyTransientCommand command in commands)
				{
					try
					{
						Factory.Release(command);
					}
					catch (Exception exception)
					{
						Log(exception);
					}
				}
			}
		}
	}
