		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.Diagnostics;
		using System.Threading;
		using System.Runtime.InteropServices;
		using System.Collections.Concurrent;
		namespace ConsoleApplication2
		{
			class Program
			{
				static ConcurrentDictionary<int, ProcessThread> threadIdsMapping = new ConcurrentDictionary<int, ProcessThread>();
				static void Main(string[] args)
				{
					Thread oThread = new Thread(
						delegate()
						{
							threadIdsMapping.GetOrAdd(Thread.CurrentThread.ManagedThreadId, GetProcessThreadFromWin32ThreadId(null));
							long counter = 1;
							while (counter < 1000000000)
							{
								counter++;
							}
						});
					oThread.Start();
					oThread.Join();
					Console.WriteLine(threadIdsMapping[oThread.ManagedThreadId].TotalProcessorTime);
					Console.WriteLine(threadIdsMapping[oThread.ManagedThreadId].UserProcessorTime);
					Console.WriteLine(DateTime.Now - threadIdsMapping[oThread.ManagedThreadId].StartTime);
					Console.ReadKey();
				}
				public static ProcessThread GetProcessThreadFromWin32ThreadId(int? threadId)
				{
					if (!threadId.HasValue)
					{
						threadId = GetCurrentWin32ThreadId();
					}
					foreach (Process process in Process.GetProcesses())
					{
						foreach (ProcessThread processThread in process.Threads)
						{
							if (processThread.Id == threadId) return processThread;
						}
					}
					throw new Exception();
				}
				[DllImport("Kernel32", EntryPoint = "GetCurrentThreadId", ExactSpelling = true)]
				public static extern Int32 GetCurrentWin32ThreadId();
			}
		}
