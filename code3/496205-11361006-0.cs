	[TestFixture]
	public class DoubleTest
	{
		private double theDouble;
		[Test]
		public void ShouldFailCalledParallell()
		{
			theDouble = 0;
			const int noOfTasks = 100;
			const int noOfLoopInTask = 100;
			var tasks = new Task[noOfTasks];
			for (var i = 0; i < noOfTasks; i++)
			{
				tasks[i] = new Task(() =>
				                    	{
				                    		for (var j = 0; j < noOfLoopInTask; j++)
				                    		{
				                    			theDouble++;
				                    		}
				                    	});
			}
			foreach (var task in tasks)
			{
				task.Start();
			}
			Task.WaitAll(tasks);
			theDouble.Should().Be.EqualTo(noOfTasks * noOfLoopInTask);
		}
	}
