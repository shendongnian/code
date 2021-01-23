	if (e.UserState == taskCompletionSource || e.UserState == taskCompletionSource?.Task.AsyncState)
	{
		if (e.Cancelled) taskCompletionSource.TrySetCanceled();
		else if (e.Error != null) taskCompletionSource.TrySetException(e.Error);
		else taskCompletionSource.TrySetResult(getResult());
		unregisterHandler();
	}
