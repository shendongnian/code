	public void SomeMethod()
	{
		Task generatedTask = null;
		{
			int someValue = 2;
			
			generatedTask = new Task(delegate{
				Console.WriteLine(someValue);
			});
		}
		someValue = 3;
		
		generatedTask.Start(); // Will write "3" to the console
	}
