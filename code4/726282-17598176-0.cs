	Task<TResult> SetContinuation<TResult>(Task<TResult> task)
	{
		return task.ContinueWith(
			t =>
				{
				 if(someCondition)
				 {
					 throw new Exception("Error");
				 }
				 return t.Result;
			});
	}
