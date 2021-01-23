    int managedThreadId = 0;
	var task = Task.Run(
		() =>
		{
			Thread.CurrentThread.Name = "Testing";
			Thread.Sleep(TimeSpan.FromDays(1));
		});
	string startOfThisNamespace = this.GetType().Namespace.ToString().Split('.')[0];
	using (DataTarget target = DataTarget.AttachToProcess(Process.GetCurrentProcess().Id, 5000, AttachFlag.Passive))
	{
		ClrRuntime runtime = target.ClrVersions.First().CreateRuntime();
		ClrHeap heap = runtime.GetHeap();
		foreach (ClrThread thread in runtime.Threads)
		{
			IList<ClrStackFrame> stackFrames = thread.StackTrace;
			List<ClrStackFrame> stackframesRelatedToUs = stackFrames
				.Where(o => o.Method != null && o.Method.ToString().StartsWith(startOfThisNamespace)).ToList();
			if (stackframesRelatedToUs.Count > 0)
			{
				Console.Write("ManagedThreadId: {0}, OSThreadId: {1}, Thread: IsAlive: {2}, IsBackground: {3}:\n", thread.ManagedThreadId, thread.OSThreadId, thread.IsAlive, thread.IsBackground);
				Console.Write("- Stack frames related namespace '{0}':\n", startOfThisNamespace);
				foreach (var s in stackframesRelatedToUs)
				{
					Console.Write("  - StackFrame: {0}\n", s.Method.ToString());
				}
			}
		}
	}
