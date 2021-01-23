	public static void Attach(this ViewModelStore ViewModelStore, DependencyObject DependencyObject) {
		// Set the changed event dispatcher.
		ViewModelStore.Dispatcher = (Key) => {
			// Begin invoking of an action on the UI dispatcher.
			DependencyObject.Dispatcher.BeginInvoke(() => {
				// Raise the changed event.
				ViewModelStore.Changed(Key);
			});
		};
	}
