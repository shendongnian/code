    class Program {
		private static long parallelIterations = 100;
		private static long taskIterations = 100000000;
		static void Main(string[] args) {
			Console.WriteLine("Parallel Iterations: {0:n0}", parallelIterations);
			Console.WriteLine("Task Iterations: {0:n0}", taskIterations);
			Analyse("Simple Threads", ExecuteWorkWithSimpleThreads);
			Analyse("ThreadPool Threads", ExecuteWorkWithThreadPoolThreads);
			Analyse("Tasks", ExecuteWorkWithTasks);
			Analyse("Parallel For", ExecuteWorkWithParallelFor);
			Analyse("Async Delegates", ExecuteWorkWithAsyncDelegates);
		}
		private static void Analyse(string name, Action action) {
			Stopwatch watch = new Stopwatch();
			watch.Start();
			action();
			watch.Stop();
			Console.WriteLine("{0}: {1} seconds", name.PadRight(20), watch.Elapsed.TotalSeconds);
		}
		private static void ExecuteWorkWithSimpleThreads() {
			Thread[] threads = new Thread[parallelIterations];
			for (long i = 0; i < parallelIterations; i++) {
				threads[i] = new Thread(DoWork);
				threads[i].Start();
			}
			for (long i = 0; i < parallelIterations; i++) {
				threads[i].Join();
			}
		}
		private static void ExecuteWorkWithThreadPoolThreads() {
			object locker = new object();
			EventWaitHandle waitHandle = new ManualResetEvent(false);
			int finished = 0;
			for (long i = 0; i < parallelIterations; i++) {
				ThreadPool.QueueUserWorkItem((threadContext) => {
					DoWork();
					lock (locker) {
						finished++;
						if (finished == parallelIterations)
							waitHandle.Set();
					}
				});
			}
			waitHandle.WaitOne();
		}
		private static void ExecuteWorkWithTasks() {
			Task[] tasks = new Task[parallelIterations];
			for (long i = 0; i < parallelIterations; i++) {
				tasks[i] = Task.Factory.StartNew(DoWork);
			}
			Task.WaitAll(tasks);
		}
		private static void ExecuteWorkWithParallelFor() {
			Parallel.For(0, parallelIterations, (n) => DoWork());
		}
		private static void ExecuteWorkWithAsyncDelegates() {
			Action[] actions = new Action[parallelIterations];
			IAsyncResult[] results = new IAsyncResult[parallelIterations];
			for (long i = 0; i < parallelIterations; i++) {
				actions[i] = DoWork;
				results[i] = actions[i].BeginInvoke((result) => { }, null);
			}
			for (long i = 0; i < parallelIterations; i++) {
				results[i].AsyncWaitHandle.WaitOne();
				results[i].AsyncWaitHandle.Close();
			}
		}
		private static void DoWork() {
			//Thread.Sleep(TimeSpan.FromMilliseconds(taskDuration));
			for (long i = 0; i < taskIterations; i++ ) { }
		}
	}
