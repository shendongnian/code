	class GameEngine : IGameEngine
	{
		private int _frameCounter;
		private Dictionary<int, TaskCompletionSource<object>> _scheduledActions;
		public GameEngine()
		{
			_scheduledActions = new Dictionary<int, TaskCompletionSource<object>>();
		}
		public void NextFrame()
		{
			if(_frameCounter == int.MaxValue)
			{
				_frameCounter = 0;
			}
			else
			{
				++_frameCounter;
			}
			TaskCompletionSource<object> completionSource;
			if(_scheduledActions.TryGetValue(_frameCounter, out completionSource))
			{
				Console.WriteLine("{0}: Current frame: {1}",
					Thread.CurrentThread.ManagedThreadId, _frameCounter);
				_scheduledActions.Remove(_frameCounter);
				completionSource.SetResult(null);
			}
			else
			{
				Console.WriteLine("{0}: Current frame: {1}, no events.",
					Thread.CurrentThread.ManagedThreadId, _frameCounter);
			}
		}
		public Task Wait(int framesToWait)
		{
			if(framesToWait < 0)
			{
				throw new ArgumentOutOfRangeException("framesToWait", "Should be non-negative.");
			}
			if(framesToWait == 0)
			{
				return Task.FromResult<object>(null);
			}
			long scheduledFrame = (long)_frameCounter + (long)framesToWait;
			if(scheduledFrame > int.MaxValue)
			{
				scheduledFrame -= int.MaxValue;
			}
			TaskCompletionSource<object> completionSource;
			if(!_scheduledActions.TryGetValue((int)scheduledFrame, out completionSource))
			{
				completionSource = new TaskCompletionSource<object>();
				_scheduledActions.Add((int)scheduledFrame, completionSource);
			}
			return completionSource.Task;
		}
	}
