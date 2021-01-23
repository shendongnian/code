	class GameEngine : IGameEngine
	{
		private int _frameCounter;
		private Dictionary<int, List<TaskCompletionSource<object>>> _scheduledActions;
		public GameEngine()
		{
			_scheduledActions = new Dictionary<int, List<TaskCompletionSource<object>>>();
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
			List<TaskCompletionSource<object>> scheduledActions;
			if(_scheduledActions.TryGetValue(_frameCounter, out scheduledActions))
			{
				Console.WriteLine("Current frame: {0}", _frameCounter);
				_scheduledActions.Remove(_frameCounter);
				foreach(var tcs in scheduledActions)
				{
					tcs.SetResult(null);
				}
			}
			else
			{
				Console.WriteLine("Current frame: {0}, no events.", _frameCounter);
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
			List<TaskCompletionSource<object>> scheduledActions;
			if(!_scheduledActions.TryGetValue((int)scheduledFrame, out scheduledActions))
			{
				scheduledActions = new List<TaskCompletionSource<object>>();
				_scheduledActions.Add((int)scheduledFrame, scheduledActions);
			}
			var tcs = new TaskCompletionSource<object>();
			scheduledActions.Add(tcs);
			return tcs.Task;
		}
	}
