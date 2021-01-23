	public class Multiplier
	{
		public LargeNumber Multiply(LargeNumber x, LargeNumber y)
		{
			return x * y;
		}
		public IAsyncResult BeginMultiply(LargeNumber x, LargeNumber y, AsyncCallback callback, object state)
		{
			AsyncResult<LargeNumber> ar = new AsyncResult<BigInteger>(callback, state);
			ThreadPool.QueueUserWorkItem(o =>
			{
				var asyncResult = (AsyncResult<LargeNumber>)o;
				try
				{
					var largeNumber = Multiply(x, y);
					asyncResult.SetAsCompleted(largeNumber, false);
				}
				catch (Exception e)
				{
					asyncResult.SetAsCompleted(e, false);
				}
			}, ar);
			return ar;
		}
		public LargeNumber EndMultiply(IAsyncResult asyncResult)
		{
			var ar = (AsyncResult<LargeNumber>)asyncResult;
			return ar.EndInvoke();
		}
		public IAsyncResult BeginMultiply(LargeNumber x, LargeNumber y, LargeNumber z, AsyncCallback callback, object state)
		{
			AsyncResult<LargeNumber> ar = new AsyncResult<LargeNumber>(callback, state);
			BeginMultiply(x, y, (asyncResult1) =>
			{
				var firstResult = EndMultiply(asyncResult1);
				BeginMultiply(firstResult, z, (asyncResult2) =>
				{
					var secondResult = EndMultiply(asyncResult2);
					ar.SetAsCompleted(secondResult, true);
				}, state);
			}, state);
			return ar;
		}
	}
