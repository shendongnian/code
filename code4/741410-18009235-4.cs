	public class TextboxTester
	{
		/* unchanged code */
		// unfortunately, there is no non-generic version of this class
		// basically it allows us to 'manually' complete Task
		private TaskCompletionSource<object> _tcs;
		public Task WriteText(string Text)
		{
			if (timer == null)
			{
				_tcs = new TaskCompletionSource<object>();
				/* unchanged code */
			}
			return _tcs.Task; // return task which tracks work completion
		}
		/* unchanged code */
				if (_currentTextLength == _text.Length)
				{
					timer.Stop();
					State.Working = false;
					timer = null;
					_tcs.TrySetResult(null); // notify completion
					return;
				}
		/* unchanged code */
	}
