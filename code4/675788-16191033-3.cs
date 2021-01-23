	[TestMethod]
	public void TestBoundedBlockingQueue()
	{
		int maxQueueSize = 8;
		using (var queue = new BoundedBlockingQueue<string>(maxQueueSize))
		{
			// Fill the queue, but don't block.
			for (int i = 0; i < maxQueueSize; ++i)
			{
				int start1 = DateTimeFunctions.TickCount;
				queue.Enqueue(i.ToString());
				int elapsed1 = DateTimeFunctions.TickCount - start1;
				Assert.IsTrue(elapsed1 < 100, "Took too long to enqueue an item.");  // Shouldn't have taken more than 100 ms to enqueue the item.
			}
			// Now if we try to enqueue something we should block (since the queue should be full).
			// We can detect this by starting a thread that will dequeue something in a few seconds
			// and then seeing how long the main thread took to enqueue something.
			// It should have taken around the thread sleep time (+/- half a second or so).
			int sleepTime = 2500;
			int tolerance = 500;
			Worker.Run(()=>{Thread.Sleep(sleepTime); queue.Dequeue();}, "TestBoundedBlockingQueue Dequeue()");
			int start2 = DateTimeFunctions.TickCount;
			queue.Enqueue(maxQueueSize.ToString());
			int elapsed2 = DateTimeFunctions.TickCount - start2;
			Assert.IsTrue(Math.Abs(elapsed2 - sleepTime) <= tolerance, "Didn't take the right time to enqueue an item.");
			// Now verify that the remaining items in the queue are the expected ones,
			// i.e. from "1".."maxQueueSize" (since the first item, "0", has been dequeued).
			for (int i = 1; i <= maxQueueSize; ++i)
			{
				Assert.AreEqual(i.ToString(), queue.Dequeue(), "Incorrect item dequeued.");
			}
			Assert.AreEqual(0, queue.Count);
			// Now if we try to dequeue something we should block (since the queue is empty).
			// We can detect this by starting a thread that will enqueue something in 5 seconds
			// and then seeing how long the main thread took to dequeue something.
			// It should have taken around 5 seconds (+/- half a second or so).
			string testValue = "TEST";
			Worker.Run(()=>{Thread.Sleep(sleepTime); queue.Enqueue(testValue);}, "TestBoundedBlockingQueue Enqueue()");
			start2 = DateTimeFunctions.TickCount;
			Assert.AreEqual(testValue, queue.Dequeue(), "Incorrect item dequeued");
			elapsed2 = DateTimeFunctions.TickCount - start2;
			Assert.IsTrue(Math.Abs(elapsed2 - sleepTime) <= tolerance, "Didn't take the right time to enqueue an item.");
		}
	}
