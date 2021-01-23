    public void QueueNotification(Notification notification)
	{
		if (this.cancelTokenSource.IsCancellationRequested)
		{
			Events.RaiseChannelException(new ObjectDisposedException("Service", "Service has already been signaled to stop"), this.Platform, notification);
			return;
		}
		notification.EnqueuedTimestamp = DateTime.UtcNow;
		queuedNotifications.Enqueue(notification);
	}
