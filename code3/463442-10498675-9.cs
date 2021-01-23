	public interface ThreadedViewModel
		: IConsumer
	{
		/// <summary>
		/// Gets the UI-thread dispatcher
		/// </summary>
		Dispatcher UIDispatcher { get; }
	}
	public static class ThreadedViewModelEx
	{
		public static void BeginInvoke([NotNull] this ThreadedViewModel viewModel, [NotNull] Action action)
		{
			if (viewModel == null) throw new ArgumentNullException("viewModel");
			if (action == null) throw new ArgumentNullException("action");
			if (viewModel.UIDispatcher.CheckAccess()) action();
			else viewModel.UIDispatcher.BeginInvoke(action);
		}
	}
