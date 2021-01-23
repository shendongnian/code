	public async Task ExecuteAsync(string executablePath)
	{
		using (var process = new Process())
		{
			// configure process
			process.StartInfo.FileName = executablePath;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			// run process asynchronously
			await process.RunAsync();
			// do stuff with results
			Console.WriteLine($"Process finished running at {process.ExitTime} with exit code {process.ExitCode}");
		};// dispose process
	}
