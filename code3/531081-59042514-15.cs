c#
var buffer = new BufferBlock<Item>();
while (await buffer.OutputAvailableAsync())
{
	if (buffer.TryReceiveAll(out var items))
		//process items
}
Here is a working example, which demos the following:
 - multiple symmetrical consumers which process variable length batches in parallel
 - multiple symmetrical producers (not truly operating in parallel in this example)
 - ability to complete the collection when the producers are done
 - to keep the example short, I did not demonstrate the use of a `CancellationToken`
 - ability to wait until the producers and/or consumers are done
 - ability to call from an area that doesn't allow async, such as a constructor
 - the `Thread.Sleep()` calls are not required, but help simulate some processing time that would occur in more taxing scenarios
 - both the `Task.WaitAll()` and the `Thread.Sleep()` can optionally be converted to their async equivalents
 - no need to use any external libraries
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
                // need to copy this due to lambda variable capture
				var num = i; 
				while (await buffer.OutputAvailableAsync())
				{
					if (buffer.TryReceiveAll(out var items))
						Console.WriteLine($"Consumer {num}:    " + 
                            items.Aggregate((a, b) => a + ", " + b));
					
                        // real life processing would take some time
                        await Task.Delay(500); 
				}
				Console.WriteLine($"Consumer {num} complete");
			}));
            // give consumer tasks time to activate for a better demo
			Thread.Sleep(100); 
		}
		// Kick off producer task(s)
		List<Task> producers = new List<Task>();
		for (int i = 0; i < 3; i++)
		{
			producers.Add(Task.Factory.StartNew(() =>
			{
				for (int j = 0 + (1000 * i); j < 500 + (1000 * i); j++)
					buffer.Post(j.ToString());
			}));
            // space out the producers for a better demo
			Thread.Sleep(10); 
		}
        // may also use the async equivalent
		Task.WaitAll(producers.ToArray());
		Console.WriteLine("Finished waiting on producers");
        // demo being able to complete the collection
		buffer.Complete(); 
        // may also use the async equivalent
		Task.WaitAll(consumers.ToArray()); 
		Console.WriteLine("Finished waiting on consumers");
		Console.ReadLine();
	}
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.dataflow.bufferblock-1
  [2]: https://www.nuget.org/packages/System.Threading.Tasks.Dataflow/4.11.0-preview3.19551.4
  [3]: http://msdn.microsoft.com/en-us/library/dd287186.aspx
  [4]: https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.dataflow.batchblock-1
