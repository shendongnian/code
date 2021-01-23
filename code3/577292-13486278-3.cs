    		[Test]
		public void TestThreading()
		{
			using ( var sample = new ThreadingSample() )
			{
				sample.AddItem(new ThreadingSample.SomeObject {Data = "First Item"});
				sample.AddItem(new ThreadingSample.SomeObject {Data = "Second Item"});
				Thread.Sleep(50);
				sample.AddItem(new ThreadingSample.SomeObject {Data = "Third Item"});
			}
		}
