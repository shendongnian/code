	Observable.Merge(
			Observable.FromEvent<ModelEventArgs>(
					h => ValuesController.ModelAdded += h,
					h => ValuesController.ModelAdded -= h),
			Observable.FromEvent<ModelEventArgs>(
					h => ValuesController.ModelDeleted += h,
					h => ValuesController.ModelDeleted -= h))
		.Subscribe(m => context.Connection.Broadcast(m));
