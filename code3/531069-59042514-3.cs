c#
var buffer = new BufferBlock<Item>();
while (await buffer.OutputAvailableAsync())
{
	if (buffer.TryReceiveAll(out var items))
		//process items
}
Here is a working example, with multiple symmetrical producers and consumers:
c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
static class Program
{
	static void Main()
	{
		var buffer = new BufferBlock<string>();
		// Kick off consumer task(s)
		List<Task> consumers = new List<Task>();
		for (int i = 0; i < 3; i++)
		{
			consumers.Add(Task.Factory.StartNew(async () =>
			{
				var num = i;
				while (await buffer.OutputAvailableAsync())
				{
					if (buffer.TryReceiveAll(out var items))
						Console.WriteLine($"C{num}:    " + items.Aggregate((a, b) => a + ", " + b));
					Thread.Sleep(100);
				}
				Console.WriteLine($"C{num} complete");
			}));
			Thread.Sleep(100); // give consumer tasks a chance to activate for a better demonstration
		}
		// Kick off producer task(s)
		List<Task> producers = new List<Task>();
		for (int i = 0; i < 3; i++)
		{
			producers.Add(Task.Factory.StartNew(() =>
			{
				for (int j = 0 + (1000 * i); j < 500 + (1000 * i); j++)
				{
					buffer.Post(j.ToString());
				}
			}
			));
			Thread.Sleep(10); // space out the producers for a better demonstration
		}
		Task.WaitAll(producers.ToArray());
		Console.WriteLine("Finished waiting on producers");
		buffer.Complete(); // complete the collection
		Task.WaitAll(consumers.ToArray());
		Console.WriteLine("Finished waiting on consumers");
		Console.ReadLine();
	}
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.dataflow.bufferblock-1
  [2]: https://www.nuget.org/packages/System.Threading.Tasks.Dataflow/4.11.0-preview3.19551.4
  [3]: http://msdn.microsoft.com/en-us/library/dd287186.aspx
  [4]: https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.dataflow.batchblock-1
